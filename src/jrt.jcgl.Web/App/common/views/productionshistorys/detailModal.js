﻿(function () {
    appModule.controller('common.views.productionshistorys.detailModal', [
        '$scope', '$modalInstance', 'entiy', 'abp.services.app.productionPlans', 'uiGridConstants',
        function ($scope, $modalInstance, entiy, productionPlansService, uiGridConstants) {
            var vm = this;
            vm.productionPlan = null;
            vm.getInfo = function () {
                productionPlansService.getProductionPlanInfo(entiy.id).success(function (result) {
                    vm.productionMainGridOptions.data = result.productionMain;
                    vm.productionPlanDetailsGridOptions.data = result.productionPlanDetails;
                    vm.productionPlan = result;
                    //vm.productionPlan.productionPlan.startDate = vm.productionPlan.productionPlan.startDate.toLocaleDateString();
                    console.log(result);
                });
            }

            vm.productionMainGridOptions = {
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                appScopeProvider: vm,
                columnDefs: [
                        {
                            name: app.localize('ProductionMain.serialNumber'),
                            field: 'serialNumber',

                        },
                        {
                            name: app.localize('ProductionMain.rawMaterialName'),
                            field: 'rawMaterialName',
                        },
                        {
                            name: app.localize('ProductionMain.plannedQuantity'),
                            field: 'plannedQuantity',
                        },
                        {
                            name: app.localize('ProductionMain.stockQuantity'),
                            field: 'stockQuantity',
                        },
                        {
                            name: app.localize('ProductionMain.productionQuantity'),
                            field: 'productionQuantity',
                        },
                        {
                            name: app.localize('ProductionMain.ps'),
                            field: 'ps',
                        },
                        {
                            name: app.localize('ProductionMain.rawMaterialRequirement'),
                            field: 'rawMaterialRequirement',
                        },
                ],
                data: []
            };

            vm.productionPlanDetailsGridOptions = {
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                appScopeProvider: vm,
                columnDefs: [
                        {
                            name: app.localize('ProductionPlanDetails.serailNum'),
                            field: 'serailNum',
                        },
                        {
                            name: app.localize('ProductionPlanDetails.rawMaterialName'),
                            field: 'rawMaterialName',
                        },
                        {
                            name: app.localize('ProductionPlanDetails.batchNum'),
                            field: 'batchNum',
                            minWidth: 120,
                        },
                        {
                            name: app.localize('ProductionPlanDetails.productionLine'),
                            field: 'productionLine',
                        },
                        {
                            name: app.localize('ProductionPlanDetails.missionQuantity'),
                            field: 'missionQuantity',
                        },
                        {
                            name: app.localize('ProductionPlanDetails.batchQuantity'),
                            field: 'batchQuantity',
                        },
                        {
                            name: app.localize('ProductionPlanDetails.missionDate'),
                            field: 'missionDate',
                            cellFilter: 'momentFormat: \'L\''
                        },
                        {
                            name: app.localize('ProductionPlanDetails.cyl'),
                            field: 'cyl',
                        },
                        {
                            name: app.localize('ProductionPlanDetails.sgl'),
                            field: 'sgl',
                        }
                ],
                data: []
            };

            vm.close = function () {
                $modalInstance.dismiss();
            };

            vm.getInfo();
        }
    ]);
})();