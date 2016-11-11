(function () {

    appModule.controller('common.views.schedulings.index', [
        '$scope', '$modal', 'uiGridConstants', 'abp.services.app.schedulings',
        function ($scope, $modal, uiGridConstants, schedulingsService) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;
            vm.filterText = null;

            var requestParams = {
                skipCount: 0,
                maxResultCount: app.consts.grid.defaultPageSize,
                sorting: null
            };

            vm.schedulingsGridOptions = {
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
                        name: app.localize('SchedulingDate'),
                        field: 'schedulingDate',
                        cellFilter: 'momentFormat: \'L\'',
                        minWidth: 100
                    },
                    {
                        name: app.localize('ExtractBatchNum'),
                        field: 'extractBatchNum',
                        minWidth: 120
                    },
                    {
                        name: app.localize('ExtractMemberName'),
                        field: 'extractMemberName',
                        minWidth: 120
                    },
                    {
                        name: app.localize('ExtractWorkInfo'),
                        field: 'extractWorkInfo',
                        enableSorting: false,
                        minWidth: 160
                    },
                    {
                        name: app.localize('MembraneBatchNum'),
                        field: 'membraneBatchNum',
                        minWidth: 120
                    },
                    {
                        name: app.localize('MembraneMemberName'),
                        field: 'membraneMemberName',
                        minWidth: 120
                    },
                    {
                        name: app.localize('MembraneWorkInfo'),
                        field: 'membraneWorkInfo',
                        minWidth: 120
                    },
                    {
                        name: app.localize('MedicinalName'),
                        field: 'medicinalName',
                        minWidth: 120
                    },
                    {
                        name: app.localize('WorkType'),
                        field: 'workType',
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents\">' +
                            '  <span ng-show="row.entity.workType==0" class="label label-success">' + app.localize('DayWork') + '</span>' +
                            '  <span ng-show="row.entity.workType==1" class="label label-warning">' + app.localize('MiddleWork') + '</span>' +
                            '  <span ng-show="row.entity.workType==2" class="label label-default">' + app.localize('NightWork') + '</span>' +
                            '</div>',
                        minWidth: 120
                    },
                    {
                        name: app.localize('Remark'),
                        field: 'remark',
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

                        vm.getschedulings();
                    });
                    gridApi.pagination.on.paginationChanged($scope, function (pageNumber, pageSize) {
                        requestParams.skipCount = (pageNumber - 1) * pageSize;
                        requestParams.maxResultCount = pageSize;

                        vm.getschedulings();
                    });
                },
                data: []
            };

            vm.getschedulings = function () {
                schedulingsService.getSchedulingList().success(function (result) {
                    vm.schedulingsGridOptions.data = result.items;
                    console.log(result);
                });
            };

            vm.createUser = function () {
                schedulingsService.schedulingWork("JP2016111801",1).success(function () { vm.getschedulings(); });
            };

            vm.getschedulings();
        }]);
})();