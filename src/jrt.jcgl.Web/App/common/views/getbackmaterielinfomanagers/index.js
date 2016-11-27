(function () {

    appModule.controller('common.views.getbackmaterielinfomanagers.index', [
        '$scope', '$modal', '$templateCache', 'uiGridConstants', 'abp.services.app.stocks',
        function ($scope, $modal, $templateCache, uiGridConstants, stocksService) {
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
            vm.startdate = null;
            vm.enddate = null;
            vm.stockslogGridOptions = {
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
                        name: app.localize('StockLog.StockName'),
                        field: 'stockName',
                        minWidth: 100
                    },
                    {
                        name: app.localize('StockLog.HandleUserName'),
                        field: 'handleUserName',
                        minWidth: 100
                    },
                    {
                        name: app.localize('StockLog.Quality'),
                        field: 'quality',
                        minWidth: 120
                    },
                    {
                        name: app.localize('StockLog.Remark'),
                        field: 'remark',
                        minWidth: 120
                    },
                    {
                        name: app.localize('StockLog.HandleTime'),
                        field: 'handleTime',
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

                        vm.getstocklog();
                    });
                    gridApi.pagination.on.paginationChanged($scope, function (pageNumber, pageSize) {
                        requestParams.skipCount = (pageNumber - 1) * pageSize;
                        requestParams.maxResultCount = pageSize;

                        vm.getstocklog();
                    });
                },
                data: []
            };

            vm.getstocklog = function () {
                stocksService.getStockInputLog({
                    skipCount: requestParams.skipCount,
                    maxResultCount: requestParams.maxResultCount,
                    sorting: requestParams.sorting,
                    filter: vm.filterText
                }).success(function (result) {
                    vm.stockslogGridOptions.totalItems = result.totalCount;
                    vm.stockslogGridOptions.data = result.items;
                }).finally(function () {
                    vm.loading = false;
                });
            };

            vm.getstocklog();
        }]);
})();