(function () {
    appModule.controller('common.views.organizationUnits.createOrEditUnitModal', [
        '$scope', '$modalInstance', 'abp.services.app.organizationUnit', 'organizationUnit',
        function ($scope, $modalInstance, organizationUnitService, organizationUnit) {
            var vm = this;

            vm.organizationUnit = organizationUnit;

            vm.type_selcet = null;
            vm.types = [];

            vm.saving = false;

            vm.save = function () {
                if (vm.organizationUnit.id) {
                    organizationUnitService
                        .updateOrganizationUnit(vm.organizationUnit)
                        .success(function (result) {
                            abp.notify.info(app.localize('SavedSuccessfully'));
                            $modalInstance.close(result);
                        });
                } else {
                    if (vm.organizationUnit.parentId && vm.organizationUnit.parentType == 2)
                        vm.organizationUnit.type = vm.type_selcet;
                    if (!vm.organizationUnit.parentType)
                        vm.organizationUnit.type = 2;
                    organizationUnitService
                        .createOrganizationUnit(vm.organizationUnit)
                        .success(function (result) {
                            abp.notify.info(app.localize('SavedSuccessfully'));
                            $modalInstance.close(result);
                        });
                }
            };

            organizationUnitService.getOrganizationTypees().success(function (result) {
                vm.types = result.items;
                deleteData("生产线");
                console.log(result);
            });

            function deleteData(name) {
                var types = vm.types;
                //alert(name);
                for (var i = 0; i < types.length; i++) {
                    var cur_type = types[i];
                    if (cur_type.name == name) {
                        vm.types.splice(i, 1);
                    }
                }
            }

            vm.cancel = function () {
                $modalInstance.dismiss();
            };
        }
    ]);
})();