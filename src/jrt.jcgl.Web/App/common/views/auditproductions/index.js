(function () {

    appModule.controller('common.views.auditproductions.index', [
        '$scope', '$modal', 'uiGridConstants', 'abp.services.app.productionPlans',
        function ($scope, $modal, uiGridConstants, productionPlansService) {
            var vm = this;
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });
            vm.loading = false;
            vm.filterText = null;
            vm.date = null;
            var requestParams = {
                skipCount: 0,
                maxResultCount: app.consts.grid.defaultPageSize,
                sorting: null
            };
            vm.auditproductionGridOptions = {
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                paginationPageSizes: app.consts.grid.defaultPageSizes,
                paginationPageSize: app.consts.grid.defaultPageSize,
                useExternalPagination: true,
                useExternalSorting: true,
                appScopeProvider: vm,
                rowTemplate: '<div ng-repeat="(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name" class="ui-grid-cell" ng-class="{ \'ui-grid-row-header-cell\': col.isRowHeader, \'text-muted\': !row.entity.isActive }"  ui-grid-cell></div>',
                columnDefs: [
                    {
                        name: 'Actions',
                        enableSorting: false,
                        width: 50,
                        headerCellTemplate: '<span></span>',
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents text-center\">' +
                                '  <button class="btn btn-default btn-xs" ng-click="grid.appScope.showDetails(row.entity)"><i class="fa fa-search"></i></button>' +
                                '</div>'
                    },
                    {
                        name: app.localize('ProductionsHistory.CreateUserName'),
                        field: 'createUserName',
                        minWidth: 100
                    },
                    {
                        name: app.localize('ProductionsHistory.Demand'),
                        field: 'demand',
                        minWidth: 100
                    },
                    {
                        name: app.localize('ProductionsHistory.AuditStatus'),
                        field: 'auditStatus',
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents\">' +
                            '  <span ng-show="row.entity.auditStatus==0" class="label label-default">' + app.localize('Enums.jrt.jcgl.ProductionPlans.AuditStatus.Submitted') + '</span>' +
                            '  <span ng-show="row.entity.auditStatus==1" class="label label-success">' + app.localize('Enums.jrt.jcgl.ProductionPlans.AuditStatus.WorkshopDirectorPass') + '</span>' +
                            '  <span ng-show="row.entity.auditStatus==2" class="label label-danger">' + app.localize('Enums.jrt.jcgl.ProductionPlans.AuditStatus.WorkshopDirectorUnPass') + '</span>' +
                            '  <span ng-show="row.entity.auditStatus==3" class="label label-success">' + app.localize('Enums.jrt.jcgl.ProductionPlans.AuditStatus.GeneralManagementPass') + '</span>' +
                            '  <span ng-show="row.entity.auditStatus==4" class="label label-danger">' + app.localize('Enums.jrt.jcgl.ProductionPlans.AuditStatus.GeneralManagementUnPass') + '</span>' +
                            '</div>',
                        minWidth: 120
                    },
                    {
                        name: app.localize('ProductionsHistory.StartDate'),
                        field: 'startDate',
                        cellFilter: 'momentFormat: \'YYYY/MM/DD\'',
                        minWidth: 120
                    }
                ],
                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                    $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                        if (!sortColumns.length || !sortColumns[0].field) {
                            requestParams.sorting = null;
                        } else {
                            requestParams.sorting = sortColumns[0].field + ' ' + sortColumns[0].sort.direction;
                        }

                        vm.getproductions();
                    });
                    gridApi.pagination.on.paginationChanged($scope, function (pageNumber, pageSize) {
                        requestParams.skipCount = (pageNumber - 1) * pageSize;
                        requestParams.maxResultCount = pageSize;

                        vm.getproductions();
                    });
                },
                data: []
            };

            vm.getproductions = function () {
                vm.loading = true;
                if (vm.date != null)
                    vm.date = vm.date.toLocaleDateString();
                productionPlansService.getProductionPlansListFForAudit({
                    skipCount: requestParams.skipCount,
                    maxResultCount: requestParams.maxResultCount,
                    sorting: requestParams.sorting,
                    filter: vm.filterText,
                    startDate: vm.date
                }).success(function (result) {
                    vm.auditproductionGridOptions.totalItems = result.totalCount;
                    vm.auditproductionGridOptions.data = result.items;
                }).finally(function () {
                    vm.loading = false;
                });
            }

            vm.showDetails = function (entiy) {
                var modalInstance = $modal.open({
                    templateUrl: '~/App/common/views/auditproductions/detailModal.cshtml',
                    controller: 'common.views.auditproductions.detailModal as vm',
                    backdrop: 'static',
                    size: 'lg',
                    resolve: {
                        entiy: function () {
                            return entiy;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    vm.getproductions();
                });
            }

            vm.getproductions();
        }]);
})();