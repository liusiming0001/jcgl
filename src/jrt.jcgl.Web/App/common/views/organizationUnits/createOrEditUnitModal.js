﻿(function () {
    appModule.controller('common.views.organizationUnits.createOrEditUnitModal', [
        '$scope', '$modalInstance', 'abp.services.app.organizationUnit', 'organizationUnit',
        function ($scope, $modalInstance, organizationUnitService, organizationUnit) {
            var vm = this;

            vm.organizationUnit = organizationUnit;

            vm.type_selcet = null;

            vm.saving = false;

            vm.save = function () {
                if (vm.organizationUnit.id) {
                    organizationUnitService
                        .updateOrganizationUnit(vm.organizationUnit)
                        .success(function(result) {
                            abp.notify.info(app.localize('SavedSuccessfully'));
                            $modalInstance.close(result);
                        });
                } else {
                    vm.organizationUnit.type = vm.type_selcet;
                    organizationUnitService
                        .createOrganizationUnit(vm.organizationUnit)
                        .success(function(result) {
                            abp.notify.info(app.localize('SavedSuccessfully'));
                            $modalInstance.close(result);
                        });
                }
            };

            vm.cancel = function () {
                $modalInstance.dismiss();
            };
        }
    ]);
})();