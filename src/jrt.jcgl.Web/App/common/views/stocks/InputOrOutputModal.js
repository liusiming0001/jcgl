(function () {
    appModule.controller('common.views.stocks.inputOrOutputModal', [
        '$scope', '$modalInstance', '$q', 'abp.services.app.stocks', 'stock', 'abp.services.app.commonLookup', 'lookupModal',
        function ($scope, $modalInstance, $q, stocksService, stock, commonLookupService, lookupModal) {
            var vm = this;
            vm.stock = stock;
            vm.stocklog = null;
            vm.userName = null;
            vm.userId = null;
            vm.value=null;
            vm.remark=null;
            console.log(stock);
            vm.saving = false;
            vm.save = function () {
                vm.saving = true;
                if (vm.stock.type == 0) {
                    stocksService.stockInput({
                        id:vm.stock.id,
                        InputValue: vm.value,
                        userId: vm.userId,
                        remark: vm.remark
                    }).success(function () {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        $modalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
                }
                else {
                    stocksService.stockOutput({
                        id: vm.stock.id,
                        OutputValue: vm.value,
                        userId: vm.userId,
                        remark: vm.remark
                    }).success(function () {
                        abp.notify.info(app.localize('SavedSuccessfully'));
                        $modalInstance.close();
                    }).finally(function () {
                        vm.saving = false;
                    });
                }
            };
            vm.openAddModal = function () {

                lookupModal.open({

                    title: app.localize('SelectAUser'),
                    serviceMethod: commonLookupService.findUsers,

                    canSelect: function (item) {
                        return $q(function (resolve, reject) {
                            resolve(item);
                        });
                    },

                    callback: function (selectedItem) {
                        vm.userName = selectedItem.name;
                        vm.userId = selectedItem.value;
                        console.log(selectedItem);
                    }
                });
            }


            vm.cancel = function () {
                $modalInstance.dismiss();
            };
        }
    ]);
})();