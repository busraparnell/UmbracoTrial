﻿angular.module("umbraco.resources")
    .factory("personResource", function ($http) {
        return {
            GetById: function(id) {
                return $http.get("backoffice/Example/PersonApi/GetById?id=" + id)
            },
            save: function (person) {
                return $http.post("backoffice/Example/PersonApi/PostSave", angular.toJson(person));
            },
            deleteById: function (id) {
                return $http.delete("backoffice/Example/PersonApi/DeleteById?id=" + id)
            }
        }
    });