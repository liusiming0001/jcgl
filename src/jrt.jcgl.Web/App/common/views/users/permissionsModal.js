﻿(function () {
    appModule.controller('common.views.users.permissionsModal', [
        '$scope', '$modalInstance', 'abp.services.app.user', 'user',
        function ($scope, $modalInstance, userService, user) {
            var vm = this;
            
            vm.saving = false;
            vm.resettingPermissions = false;
            vm.user = user;
            vm.permissionEditData = null;

            vm.resetPermissions = function () {
                vm.resettingPermissions = true;
                userService.resetUserSpecificPermissions({
                    id: vm.user.id
                }).success(function () {
                    abp.notify.info(app.localize('ResetSuccessfully'));
                    loadPermissions();
                }).finally(function () {
                    vm.resettingPermissions = false;
                });
            };

            vm.save = function () {
                vm.saving = true;
                userService.updateUserPermissions({
                    id: vm.user.id,
                    grantedPermissionNames: vm.permissionEditData.grantedPermissionNames
                }).success(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    $modalInstance.close();
                }).finally(function () {
                    vm.saving = false;
                });
            };

            vm.cancel = function () {
                $modalInstance.dismiss();
            };

            function loadPermissions() {
                userService.getUserPermissionsForEdit({
                    id: vm.user.id
                }).success(function (result) {
                    vm.permissionEditData = result;
                });
            }

            loadPermissions();
        }
    ]);
})();