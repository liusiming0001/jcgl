(function () {
    appModule.controller('common.views.rawmaterials.createOrEditModal', [
        '$scope', '$modalInstance', 'abp.services.app.rawMaterial', 'rawmaterialId',
        function ($scope, $modalInstance, rawMaterialService, rawmaterialId) {
            var vm = this;

            vm.saving = false;
            vm.raw = null;
            vm.select_Type = null;
            vm.types = [];
            vm.constantTypes = [];
            vm.constant = [];
            vm.save = function () {
                vm.saving = true;
                vm.raw.units = vm.select_Type.value;
                rawMaterialService.createOrUpdateRawMaterial(
                    vm.raw
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
                rawMaterialService.getRawMaterialConstantTypes().success(function (result) {
                    vm.constantTypes = result.items;
                    console.log(result.items);
                }).finally(function () {
                    vm.getEdit();
                });
                rawMaterialService.getUnitsTypes(rawmaterialId).success(function (result) {
                    vm.types = result.items;
                    console.log(result.items);
                });

 
            }
            vm.getEdit = function () {
                rawMaterialService.getRawMaterialForEdit(rawmaterialId).success(function (result) {
                    vm.raw = result;
                    vm.types.map(r=> {
                        if (r.value == vm.raw.units) {
                            vm.select_Type = r;
                        }
                    });
                    if (vm.raw.constant.length==0)
                        vm.constantTypes.forEach(function (val, index, arr) {
                            vm.raw.constant.push({
                                type: arr[index].value,
                                constant: null,
                                name: arr[index].name
                            });
                        });
                    console.log(vm.raw);
                    console.log(vm.constant);
                });
            }

            init();
        }
    ]);
})();