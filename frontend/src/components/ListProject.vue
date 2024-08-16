<template>
<div>
    <b-row no-gutters class="d-flex align-items-center p-3">
        <b-col md="11">
            <h1>Projects</h1>
        </b-col>
        <b-col md="1">
            <b-button variant="success" class="me-2" @click="createProject" >+ New</b-button>
        </b-col>
    </b-row>
</div>
<div v-for="(project, index) in this.projects" :key="index">
    <b-card no-body class="overflow-hidden">
        <b-row no-gutters>
            <b-col md="10">
                <b-card-body>
                    <b-card-text>
                        {{ project.name }}
                    </b-card-text>
                </b-card-body>
            </b-col>
            <b-col md="2">
                <b-card-body class="d-flex">
                    <b-button variant="primary" class="me-2" @click="editProject(project.id)">Edit</b-button>
                    <b-button variant="danger" @click="deleteProject(project.id)">Delete</b-button>
                </b-card-body>
            </b-col>
        </b-row>
    </b-card>
</div>
</template>
    
<script>
import ProjectService from '@/services/ProjectService';

    export default {
      name: 'ListProject',
      data() {
        return {
            projects: null
        };
      },
      created() {
        this.getProjects();
     },
      methods: 
      {
        async getProjects()
        {
            try
            {
                const response = await ProjectService.getAll();
                this.projects = response.data;
            }
            catch(error)
            {
                console.error('Error fetching data:', error);
            }
        },
        editProject(id) {
            this.$router.push({ name: 'EditProject', params: { id } });
        },
        createProject() {
            this.$router.push({ name: 'NewProject'});
        },
        async deleteProject(id) {
            if(confirm(`Tem certeza que deseja excluir o projeto ${id}?`))
            {
                await ProjectService.delete(id);
                this.getProjects();
            }
            
        }
      }
    };
</script>
    
<style scoped>

</style>