(function () {

    appModule.controller('common.views.stocks.index', [
        '$scope', '$modal', '$templateCache', 'abp.services.app.stocks', 'uiGridConstants',
        function ($scope, $modal, $templateCache, stocksService, uiGridConstants) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;

            vm.permissions = {
                edit: abp.auth.hasPermission('Pages.ProductionManagers.Stocks.Edit'),
            };

            vm.stockGridOptions = {
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                appScopeProvider: vm,
                columnDefs: [
                    {
                        name: app.localize('Actions'),
                        enableSorting: false,
                        minWidth: 120,
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents\">' +
                            '  <div class="btn-group dropdown" dropdown="">' +
                            '    <button class="btn btn-xs btn-primary blue" dropdown-toggle="" aria-haspopup="true" aria-expanded="false"><i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span></button>' +
                            '    <ul class="dropdown-menu">' +
                            '      <li><a ng-if="grid.appScope.permissions.edit" ng-click="grid.appScope.inputStock(row.entity)">' + app.localize('Enums.jrt.jcgl.Stocks.StockLogType.Input') + '</a></li>' +
                            '      <li><a ng-if="grid.appScope.permissions.edit" ng-click="grid.appScope.outputStock(row.entity)">' + app.localize('Enums.jrt.jcgl.Stocks.StockLogType.Output') + '</a></li>' +
                            '    </ul>' +
                            '  </div>' +
                            '</div>'
                    },
                    {
                        name: app.localize('Stock.RawMaterialName'),
                        field: 'rawMaterialName',
                        minWidth: 120,
                    },
                    {
                        name: app.localize('Stock.StockValue'),
                        field: 'stockValue',
                        minWidth: 120,
                    },
                    {
                        name: app.localize('Stock.Type'),
                        field: 'type',
                        cellTemplate:
                            '<div class=\"ui-grid-cell-contents\">' +
                            '  <span ng-show="row.entity.type==0" class="label label-success">' + app.localize('Enums.jrt.jcgl.Stocks.StockType.YL') + '</span>' +
                            '  <span ng-show="row.entity.type==1" class="label label-warning">' + app.localize('Enums.jrt.jcgl.Stocks.StockType.NSY') + '</span>' +
                            '</div>',
                        minWidth: 120,
                    }
                ],
                data: []
            };

            vm.getStocks = function () {
                vm.loading = true;
                stocksService.getStockList({}).success(function (data) {
                    vm.stockGridOptions.data = data.items;
                    console.log(data.items);
                }).finally(function () {
                    vm.loading = false;
                });
            };

            vm.inputStock = function (stock) {
                var typename = null;
                if (stock.type == 0)
                    typename = app.localize('Enums.jrt.jcgl.Stocks.StockType.YL');
                else
                    typename = app.localize('Enums.jrt.jcgl.Stocks.StockType.NSY');
                inputOrOutputModal({ id: stock.id, type: 0, name: stock.rawMaterialName + typename });
            };
            vm.outputStock = function (stock) {
                var typename = null;
                if (stock.type == 0)
                    typename = app.localize('Enums.jrt.jcgl.Stocks.StockType.YL');
                else
                    typename = app.localize('Enums.jrt.jcgl.Stocks.StockType.NSY');
                inputOrOutputModal({ id: stock.id, type: 1, name: stock.rawMaterialName + typename });
            };

            function inputOrOutputModal(stock) {
                var modalInstance = $modal.open({
                    templateUrl: '~/App/common/views/stocks/inputOrOutputModal.cshtml',
                    controller: 'common.views.stocks.inputOrOutputModal as vm',
                    backdrop: 'static',
                    resolve: {
                        stock: function () {
                            return stock;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    vm.getStocks();
                });
            }

            vm.getStocks();
        }
    ]);
})();