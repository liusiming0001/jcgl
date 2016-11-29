(function () {

    appModule.controller('common.views.makingproductions.index', [
        '$scope', '$modal', 'uiGridConstants', 'abp.services.app.productionPlans', 'abp.services.app.commonLookup', 'lookupModal', '$q',
        function ($scope, $modal, uiGridConstants, productionPlansService, commonLookupService, lookupModal, $q) {
            var vm = this;
            vm.value = null;
            vm.startdate = null;
            vm.types = [];
            vm.type_selcet = null;
            vm.organzations = [];
            vm.loading = false;
            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });
            vm.createProductionPlan = function () {
                vm.loading = true;
                if (vm.startdate != null)
                    vm.startdate = vm.startdate.toLocaleDateString();
                var member = new Array(vm.organzations.length);
                for (var i = 0; i < vm.organzations.length; i++) {
                    member[i] = vm.organzations[i].value;
                }
                productionPlansService.createProductionPlans({
                    startDateTime: vm.startdate,
                    value: vm.value,
                    restType: vm.type_selcet.value,
                    organzations: member
                }).success(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    vm.value = null;
                    vm.startdate = null;
                    vm.type_selcet = null;
                    vm.organzations = [];
                    vm.loading = false;
                });
            }

            vm.addorganzation = function () {
                lookupModal.open({

                    title: app.localize('SelectASCX'),
                    serviceMethod: commonLookupService.findSCX,

                    canSelect: function (item) {
                        return $q(function (resolve, reject) {
                            resolve(item);
                        });
                    },

                    callback: function (selectedItem) {
                        var items = vm.organzations;
                        var flag = true;
                        //alert(name);
                        for (var i = 0; i < items.length; i++) {
                            var item = items[i];
                            if (item.name == selectedItem.name) {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                            vm.organzations.push(selectedItem);
                    }
                });
            }

            vm.deleteorganzation = function (name) {
                deleteData(name);
            }

            function deleteData(name) {
                var items = vm.organzations;
                //alert(name);
                for (var i = 0; i < items.length; i++) {
                    var item = items[i];
                    if (item.name == name) {
                        vm.organzations.splice(i, 1);
                    }
                }
            }

            vm.init = function () {
                productionPlansService.getSchedulingTypes().success(function (result) {
                    vm.types = result.items;
                    console.log(result);
                });

            }

            vm.init();
        }]);
})();