﻿using Abp.Dependency;
using Abp.Domain.Repositories;
using jrt.jcgl.CustomHolidays;
using jrt.jcgl.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Schedulings
{
    public class SchedulingManager : ITransientDependency, ISchedulingManager
    {
        private readonly IRepository<Scheduling, long> _schedulingRepository;
        private readonly IRepository<Organization, long> _organizationRepository;
        private readonly IRepository<CustomHoliday, long> _cusomHolidayRepository;
        public SchedulingManager(IRepository<Scheduling, long> _personRepository,
            IRepository<Organization, long> _organizationRepository,
            IRepository<CustomHoliday, long> _cusomHolidayRepository)
        {
            this._schedulingRepository = _personRepository;
            this._organizationRepository = _organizationRepository;
            this._cusomHolidayRepository = _cusomHolidayRepository;
        }
        /// <summary>
        /// 根据批号预排班
        /// </summary>
        /// <param name="BatchNum"></param>
        /// <returns></returns>
        public async Task SchedulingWork(string BatchNum, string ExtractWorkInfo, string MembraneWorkInfo, string MedicinalName, string Remark, SchedulingType type)
        {
            try
            {

                switch (type)
                {
                    case SchedulingType.Normal: await SchedulingType1(BatchNum, ExtractWorkInfo, MembraneWorkInfo, MedicinalName, Remark); break;
                    case SchedulingType.Single: await SchedulingType2(BatchNum, ExtractWorkInfo, MembraneWorkInfo, MedicinalName, Remark); break;
                    case SchedulingType.Custom: await SchedulingType3(BatchNum, ExtractWorkInfo, MembraneWorkInfo, MedicinalName, Remark); break;
                    default: break;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #region 获取上班人员
        /// <summary>
        /// 根据生产批号获取日期
        /// </summary>
        /// <param name="BatchNum"></param>
        /// <returns></returns>
        private DateTime BatchNumConvertToDate(string BatchNum, int i)
        {
            int year = Convert.ToInt32(BatchNum.Substring(2, 4));
            int month = Convert.ToInt32(BatchNum.Substring(6, 2));
            int day = Convert.ToInt32(BatchNum.Substring(8, 2)) + i;
            if ((month == 1 ||
                month == 3 ||
                month == 5 ||
                month == 7 ||
                month == 8 ||
                month == 10) && day > 31)
            {
                month++;
                day = i;
            }
            if (month == 12 && day > 31)
            {
                month = 1;
                year++;
                day = i;
            }
            if ((month == 4 ||
                month == 6 ||
                month == 9 ||
                month == 11) && day > 30)
            {
                month++;
                day = i;
            }
            if (year % 4 == 0 && month == 2 && day > 29)
            {
                month++;
                day = i;
            }
            if (year % 4 != 0 && month == 2 && day > 28)
            {
                month++;
                day = i;
            }
            return new DateTime(year, month, day);
        }
        /// <summary>
        /// 分配生产人员
        /// </summary>
        /// <param name="date"></param>
        /// <param name="workttpe"></param>
        /// <returns></returns>
        private int DistributionMember(int date, int worktype)
        {
            int member = date + worktype;
            if (member >= 3)
                member = member - 3;
            return member;
        }
        /// <summary>
        /// 获取提取组
        /// </summary>
        /// <returns></returns>
        private async Task<List<OrganizationMember>> getExtract()
        {
            List<OrganizationMember> list = new List<OrganizationMember>();

            var Extract = await _organizationRepository.GetAllListAsync(o => o.Type == OrganizationType.Extract && o.OrganizationUnit.ParentId != null);
            if (Extract.Count >= 3)
                for (int i = 0; i < 3; i++)
                {
                    list.Add(new OrganizationMember
                    {
                        Num = i,
                        OrganizationUnitId = Extract[i].OrganizationUnitId
                    });
                }

            return list;
        }
        /// <summary>
        /// 获取膜组
        /// </summary>
        /// <returns></returns>
        private async Task<List<OrganizationMember>> getMembrane()
        {
            List<OrganizationMember> list = new List<OrganizationMember>();

            var Membrane = await _organizationRepository.GetAllListAsync(o => o.Type == OrganizationType.Membrane && o.OrganizationUnit.ParentId != null);
            if (Membrane.Count >= 3)
                for (int i = 0; i < 3; i++)
                {
                    list.Add(new OrganizationMember
                    {
                        Num = i,
                        OrganizationUnitId = Membrane[i].OrganizationUnitId
                    });
                }

            return list;
        }
        #endregion
        #region 休息日类型
        private bool isHolidayType1(DateTime day)
        {
            ///API未更新数据源 ！
            string url = string.Format("http://www.easybots.cn/api/holiday.php?d={0}", day.ToString("yyyyMMdd"));
            WebClient wc = new WebClient();
            Encoding enc = Encoding.GetEncoding("UTF-8");
            byte[] pageData = wc.DownloadData(url);
            string re = enc.GetString(pageData);
            var a = re.Substring(13, 1);

            if (a == "0")
                return false;
            else
                return true;
        }
        private bool isHolidayType2(DateTime day)
        {
            string url = string.Format("http://www.easybots.cn/api/holiday.php?d={0}", day.ToString("yyyyMMdd"));
            WebClient wc = new WebClient();
            Encoding enc = Encoding.GetEncoding("UTF-8");
            byte[] pageData = wc.DownloadData(url);
            string re = enc.GetString(pageData);
            var a = re.Substring(13, 1);

            if (a == "0")
                return false;
            else if (a != "0" && day.DayOfWeek == DayOfWeek.Saturday)
                return false;
            else
                return true;
        }
        private bool isHolidayType3(DateTime day)
        {
            var holiyday = _cusomHolidayRepository.FirstOrDefault(c => c.Holiday == day);
            if (holiyday == null)
                return false;
            return true;
        }
        #endregion
        #region 排版类型
        /// <summary>
        /// 正常休假
        /// </summary>
        /// <param name="BatchNum"></param>
        /// <returns></returns>
        private async Task SchedulingType1(string BatchNum, string ExtractWorkInfo, string MembraneWorkInfo, string MedicinalName, string Remark)
        {
            var extract = await getExtract();
            var membrane = await getMembrane();
            #region 考虑节假日版本
            int day = 0;
            int count = 0;
            while (true)
            {
                var workdate = BatchNumConvertToDate(BatchNum, day);
                if (!isHolidayType1(workdate))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        await InserScheduling(workdate,extract,membrane,count,j,BatchNum,ExtractWorkInfo,MembraneWorkInfo,MedicinalName,Remark);
                        //var date = workdate;
                        //var exscheduling = await _schedulingRepository.FirstOrDefaultAsync(s => s.SchedulingDate == date && s.WorkType == (WorkType)j);
                        //if (exscheduling == null)
                        //    await _schedulingRepository.InsertAsync(new Scheduling
                        //    {
                        //        SchedulingDate = workdate,
                        //        ExtractBatchNum = count <= 2 ? BatchNum : null,
                        //        MembraneBatchNum = count >= 2 ? BatchNum : null,
                        //        WorkType = (WorkType)j,
                        //        ExtractMemberId = count <= 2 ? (long?)extract[DistributionMember(count, j)].OrganizationUnitId : null,
                        //        MembraneMemberId = count >= 2 ? (long?)membrane[DistributionMember(count - 2, j)].OrganizationUnitId : null,
                        //        ExtractWorkInfo = count <= 2 ? ExtractWorkInfo : null,
                        //        MembraneWorkInfo = count >= 2 ? MembraneWorkInfo : null,
                        //        MedicinalName = MedicinalName,
                        //        Remark = Remark
                        //    });
                        //else
                        //{
                        //    exscheduling.ExtractBatchNum = count <= 2 ? BatchNum : null;
                        //    exscheduling.ExtractMemberId = count <= 2 ? (long?)extract[DistributionMember(count, j)].OrganizationUnitId : exscheduling.ExtractMemberId;
                        //    ExtractWorkInfo = count <= 2 ? ExtractWorkInfo : null;
                        //    await _schedulingRepository.UpdateAsync(exscheduling);
                        //}
                    }
                    count++;
                }
                day++;
                if (count == 5)
                    break;
            }
            #endregion
        }
        /// <summary>
        /// 单休+节假日
        /// </summary>
        /// <param name="BatchNum"></param>
        /// <returns></returns>
        private async Task SchedulingType2(string BatchNum, string ExtractWorkInfo, string MembraneWorkInfo, string MedicinalName, string Remark)
        {
            var extract = await getExtract();
            var membrane = await getMembrane();
            #region 考虑节假日版本
            int day = 0;
            int count = 0;
            while (true)
            {
                var workdate = BatchNumConvertToDate(BatchNum, day);
                if (!isHolidayType2(workdate))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        await InserScheduling(workdate, extract, membrane, count, j, BatchNum, ExtractWorkInfo, MembraneWorkInfo, MedicinalName, Remark);
                        //var date = workdate;
                        //var exscheduling = await _schedulingRepository.FirstOrDefaultAsync(s => s.SchedulingDate == date && s.WorkType == (WorkType)j);
                        //if (exscheduling == null)
                        //    await _schedulingRepository.InsertAsync(new Scheduling
                        //    {
                        //        SchedulingDate = workdate,
                        //        ExtractBatchNum = count <= 2 ? BatchNum : null,
                        //        MembraneBatchNum = count >= 2 ? BatchNum : null,
                        //        WorkType = (WorkType)j,
                        //        ExtractMemberId = count <= 2 ? (long?)extract[DistributionMember(count, j)].OrganizationUnitId : null,
                        //        MembraneMemberId = count >= 2 ? (long?)membrane[DistributionMember(count - 2, j)].OrganizationUnitId : null,
                        //        ExtractWorkInfo = count <= 2 ? ExtractWorkInfo : null,
                        //        MembraneWorkInfo = count >= 2 ? MembraneWorkInfo : null,
                        //        MedicinalName = MedicinalName,
                        //        Remark = Remark
                        //    });
                        //else
                        //{
                        //    exscheduling.ExtractBatchNum = count <= 2 ? BatchNum : null;
                        //    exscheduling.ExtractMemberId = count <= 2 ? (long?)extract[DistributionMember(count, j)].OrganizationUnitId : exscheduling.ExtractMemberId;
                        //    ExtractWorkInfo = count <= 2 ? ExtractWorkInfo : null;
                        //    await _schedulingRepository.UpdateAsync(exscheduling);
                        //}
                    }
                    count++;
                }
                day++;
                if (count == 5)
                    break;
            }
            #endregion
        }
        /// <summary>
        /// 自定义上班
        /// </summary>
        /// <param name="BatchNum"></param>
        /// <returns></returns>
        private async Task SchedulingType3(string BatchNum, string ExtractWorkInfo, string MembraneWorkInfo, string MedicinalName, string Remark)
        {
            var extract = await getExtract();
            var membrane = await getMembrane();
            #region 考虑节假日版本
            int day = 0;
            int count = 0;
            while (true)
            {
                var workdate = BatchNumConvertToDate(BatchNum, day);
                if (!isHolidayType3(workdate))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        await InserScheduling(workdate, extract, membrane, count, j, BatchNum, ExtractWorkInfo, MembraneWorkInfo, MedicinalName, Remark);
                        //var date = workdate;
                        //var exscheduling = await _schedulingRepository.FirstOrDefaultAsync(s => s.SchedulingDate == date && s.WorkType == (WorkType)j);
                        //if (exscheduling == null)
                        //    await _schedulingRepository.InsertAsync(new Scheduling
                        //    {
                        //        SchedulingDate = workdate,
                        //        ExtractBatchNum = count <= 2 ? BatchNum : null,
                        //        MembraneBatchNum = count >= 2 ? BatchNum : null,
                        //        WorkType = (WorkType)j,
                        //        ExtractMemberId = count <= 2 ? (long?)extract[DistributionMember(count, j)].OrganizationUnitId : null,
                        //        MembraneMemberId = count >= 2 ? (long?)membrane[DistributionMember(count - 2, j)].OrganizationUnitId : null,
                        //        ExtractWorkInfo = count <= 2 ? ExtractWorkInfo : null,
                        //        MembraneWorkInfo = count >= 2 ? MembraneWorkInfo : null,
                        //        MedicinalName = MedicinalName,
                        //        Remark = Remark
                        //    });
                        //else
                        //{
                        //    exscheduling.ExtractBatchNum = count <= 2 ? BatchNum : null;
                        //    exscheduling.ExtractMemberId = count <= 2 ? (long?)extract[DistributionMember(count, j)].OrganizationUnitId : exscheduling.ExtractMemberId;
                        //    ExtractWorkInfo = count <= 2 ? ExtractWorkInfo : null;
                        //    await _schedulingRepository.UpdateAsync(exscheduling);
                        //}
                    }
                    count++;
                }
                day++;
                if (count == 5)
                    break;
            }
            #endregion
        }

        private async Task InserScheduling(DateTime workdate,
            List<OrganizationMember> extract, List<OrganizationMember> membrane,
            int count, int j,
            string BatchNum, string ExtractWorkInfo, string MembraneWorkInfo, string MedicinalName, string Remark)
        {
            var exscheduling = await _schedulingRepository.FirstOrDefaultAsync(s => s.SchedulingDate == workdate && s.WorkType == (WorkType)j);
            if (exscheduling == null)
                await _schedulingRepository.InsertAsync(new Scheduling
                {
                    SchedulingDate = workdate,
                    ExtractBatchNum = count <= 2 ? BatchNum : null,
                    MembraneBatchNum = count >= 2 ? BatchNum : null,
                    WorkType = (WorkType)j,
                    ExtractMemberId = count <= 2 ? (long?)extract[DistributionMember(count, j)].OrganizationUnitId : null,
                    MembraneMemberId = count >= 2 ? (long?)membrane[DistributionMember(count - 2, j)].OrganizationUnitId : null,
                    ExtractWorkInfo = count <= 2 ? ExtractWorkInfo : null,
                    MembraneWorkInfo = count >= 2 ? MembraneWorkInfo : null,
                    MedicinalName = MedicinalName,
                    Remark = Remark
                });
            else
            {
                exscheduling.ExtractBatchNum = count <= 2 ? BatchNum : null;
                exscheduling.ExtractMemberId = count <= 2 ? (long?)extract[DistributionMember(count, j)].OrganizationUnitId : exscheduling.ExtractMemberId;
                exscheduling.ExtractWorkInfo = count <= 2 ? ExtractWorkInfo : null;
                await _schedulingRepository.UpdateAsync(exscheduling);
            }
        }
        #endregion

    }

    public class OrganizationMember
    {
        public int Num { get; set; }

        public long OrganizationUnitId { get; set; }
    }
}
