using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using jrt.jcgl.RawMaterials.Dto;
using jrt.jcgl.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.RawMaterials
{
    public class RawMaterialAppService : AbpZeroTemplateAppServiceBase, IRawMaterialAppService
    {
        #region 变量
        private readonly IRepository<RawMaterial> _rawMaterialRepository;
        private readonly IRepository<Stock> _stockRepository;
        private readonly IRepository<RawMaterialConstant> _rawMaterialConstantRepository;
        #endregion

        #region 构造函数
        public RawMaterialAppService(
            IRepository<RawMaterial> _rawMaterialRepository,
            IRepository<Stock> _stockRepository,
            IRepository<RawMaterialConstant> _rawMaterialConstantRepository)
        {
            this._rawMaterialRepository = _rawMaterialRepository;
            this._stockRepository = _stockRepository;
            this._rawMaterialConstantRepository = _rawMaterialConstantRepository;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 更新或创建药品
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateRawMaterial(CreateOrUpdateDto input)
        {
            if (input.Id.HasValue)
                await UpdateRawMaterial(input);
            else
                await CreateRawMaterial(input);
        }
        /// <summary>
        /// 更新信息详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CreateOrUpdateDto> GetRawMaterialForEdit(int? id)
        {
            if (id.HasValue)
            {
                var raw = await _rawMaterialRepository.FirstOrDefaultAsync((int)id);
                if (raw == null)
                    throw new UserFriendlyException("无法找到该药品信息。");
                var output = raw.MapTo<CreateOrUpdateDto>();
                var constants = raw.RawMaterialConstant.MapTo<List<RawMaterialConstantDto>>();
                output.Constant = constants;
                return output;
            }
            else
                return new CreateOrUpdateDto();
        }
        public async Task<ListResultOutput<RawMaterialListDto>> GetRawMaterialList()
        {
            var raw = await _rawMaterialRepository.GetAllListAsync();
            return new ListResultOutput<RawMaterialListDto>(raw.MapTo<List<RawMaterialListDto>>());
        }
        /// <summary>
        /// 删除原料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteRawMaterial(int id)
        {
            await _rawMaterialRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 获取计量单位枚举
        /// </summary>
        /// <returns></returns>
        public ListResultDto<NameValueDto> GetUnitsTypes()
        {
            return EnumToNameValueList<UnitsType>();
        }
        /// <summary>
        /// 获取原料参数枚举
        /// </summary>
        /// <returns></returns>
        public ListResultDto<NameValueDto> GetRawMaterialConstantTypes()
        {
            return EnumToNameValueList<RawMaterialConstantType>();
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private async Task CreateRawMaterial(CreateOrUpdateDto input)
        {
            var raw = await _rawMaterialRepository.FirstOrDefaultAsync(r => r.Name == input.Name);
            if (raw != null)
                throw new UserFriendlyException("该药品名称已被录入，请仔细检查输入信息。");
            var entiy = input.MapTo<RawMaterial>();
            var constant = input.Constant.MapTo<ICollection<RawMaterialConstant>>();
            entiy.RawMaterialConstant = constant;
            await _rawMaterialRepository.InsertAsync(entiy);
            await _stockRepository.InsertAsync(new Stock
            {
                RawMaterialId = entiy.Id,
                Type = StockType.YL,
                StockValue = 0
            });
            await _stockRepository.InsertAsync(new Stock
            {
                RawMaterialId = entiy.Id,
                Type = StockType.NSY,
                StockValue = 0
            });
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private async Task UpdateRawMaterial(CreateOrUpdateDto input)
        {
            var raw = await _rawMaterialRepository.FirstOrDefaultAsync(r => r.Name == input.Name);
            if (raw == null)
                throw new UserFriendlyException("无法找到要更新的药品。");
            var entiy = input.MapTo(raw);
            var constant = input.Constant.MapTo<ICollection<RawMaterialConstant>>();
            entiy.RawMaterialConstant = constant;
            await _rawMaterialRepository.UpdateAsync(entiy);
        } 
        #endregion

    }
}
