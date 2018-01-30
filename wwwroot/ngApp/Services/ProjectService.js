    class ProjectService {

        constructor($resource) {
            console.log('resource', $resource);
            this.ProjectResource = $resource('/api/projects/:id');
        }

        listProjects() {
            console.log("service");
            return this.ProjectResource.query().$promise;
        }

        save(project) {
            return this.ProjectResource.save(project).$promise;
        }

        getProject(id) {
            return this.ProjectResource.get({ id: id });
        }

        deleteProject(id) {
            return this.ProjectResource.delete({ id: id }).$promise;
        }

    }

    ProjectService.$inject = ['$resource'];
    angular.module('MyApp').service('projectService', ProjectService);