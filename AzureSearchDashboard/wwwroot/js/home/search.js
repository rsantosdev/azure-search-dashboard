(function (angular) {
    angular.module('AzureSearchDashBoard', [])
        .controller('SearchController', function ($http) {
            var self = this;

            self.indexNames = [];
            self.selectedIndex = null;
            self.index = null;
            self.selectedFields = [];
            self.searchQuery = null;
            self.data = [];

            self.indexChanged = indexChanged;
            self.manageField = manageField;
            self.queryIndex = queryIndex;

            function init() {
                $http.get('/api/index/list-names')
                    .then(function (result) {
                        self.indexNames = result.data;
                    });
            }

            function indexChanged() {
                $http.get('/api/index/' + self.selectedIndex + '/metadata')
                    .then(function (result) {
                        self.index = result.data;
                    });
            }

            function manageField(field) {
                var idx = self.selectedFields.indexOf(field);
                if (idx >= 0) {
                    self.selectedFields.splice(idx, 1);
                    field.selected = false;
                } else {
                    self.selectedFields.push(field);
                    field.selected = true;
                }
            }

            function queryIndex() {
                if (self.searchQuery && self.searchQuery.length) {
                    $http.get('/api/index/' + self.selectedIndex + '/search?query=' + self.searchQuery)
                        .then(function (result) {
                            self.data = result.data;
                        });
                }
            }

            init();
        });
})(angular);