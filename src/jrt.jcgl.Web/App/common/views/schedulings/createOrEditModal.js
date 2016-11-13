(function () {
    appModule.controller('common.views.schedulings.createOrEditModal', [
        '$scope', '$modalInstance', 'abp.services.app.schedulings',
        function ($scope, $modalInstance, schedulingsService) {
            var vm = this;

            vm.saving = false;
            vm.scheduling = null;
            vm.types = [];
            vm.type_selcet = null;
            vm.save = function () {
                vm.saving = true;
                vm.scheduling.type = vm.type_selcet.value;
                schedulingsService.schedulingWork(
                    vm.scheduling
                ).success(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    $modalInstance.close();
                }).finally(function () {
                    vm.saving = false;
                });
            };

            vm.cancel = function () {
                $modalInstance.dismiss();
            };

            function init() {
                schedulingsService.initCreateDto().success(function (result) {
                    vm.scheduling = result;
                    console.log(result);
                });

                schedulingsService.getSchedulingTypes().success(function (result) {
                    vm.types = result.items;
                    console.log(result);
                });
            }

            init();
        }
    ]);
})();