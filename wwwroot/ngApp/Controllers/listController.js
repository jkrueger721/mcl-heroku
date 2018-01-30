class ListController {

    constructor(projectService) {
        console.log("Controller");
        this.projects = [];
        projectService.listProjects().then((data) => {
            this.projects = data;
        });
    }
}

ListController.$inject = ['projectService'];

class ProjectsAddController {

    constructor(projectService, $state) {
        this.projectService = projectService;
        this.$state = $state;
    }

    addProject() {
        this.projectServiceie.save(this.projectToCreate).then(
            () => this.$state.go('Home')
        );
    }
}

ProjectsAddController.$inject = ['projectService', '$state'];

class ProjectsEditController {

    constructor(projectService, $state, $stateParams) {
        this.projectToEdit = projectService.getProject($stateParams['id']);
        this.$state = $state;
        this.projectService = projectService;
    }

    editProject() {
        this.projectService.save(this.projectToEdit).then(
            () => this.$state.go('Home')
        );
    }

}

ProjectsEditController.$inject = ['projectService', '$state', '$stateParams'];

class ProjectsDeleteController {

    constructor(projectService, $state, $stateParams) {
        this.projectToDelete = projectService.getProject($stateParams['id']);
        this.$state = $state;
        this.projectService = projectService;
    }

    deleteProject() {
        this.projectService.deleteProject(this.projectToDelete.id).then(
            () => this.$state.go('Home')
        );
    }

}

ProjectsDeleteController.$inject = ['projectService', '$state', '$stateParams'];