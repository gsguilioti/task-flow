<template>
    <div>
      <b-card>
        <b-card-body>
          <h2>Edit Project</h2>
          <b-form @submit.prevent="updateProject">
            <b-form-group label="Project Name:" label-for="project-name">
              <b-form-input
                id="project-name"
                v-model="project.name"
                required
              >{{ this.project.name }}</b-form-input>
            </b-form-group>
            
            <b-button type="submit" variant="primary">Save</b-button>
            <b-button @click="cancel" variant="secondary" class="ms-2">Cancel</b-button>
          </b-form>
        </b-card-body>
      </b-card>
    </div>
  </template>
  
  <script>
  import { useRoute } from 'vue-router';
  import ProjectService from '@/services/ProjectService';
  
  export default {
    name: 'EditProject',
    data() {
      return {
        project: {
          name: ''
        },
        id: null
      };
    },
    created() {
      const route = useRoute();
      this.id = route.params.id;
      this.getProject();
    },
    methods: {
      async getProject() {
        try {
          const response = await ProjectService.getById(this.id);
          this.project = response.data;
        } catch (error) {
          console.error('Error fetching project data:', error);
        }
      },
      async updateProject() {
        try {
          await ProjectService.update(this.id, this.project);
          this.$router.push('/projects');
        } catch (error) {
          console.error('Error updating project:', error);
        }
      },
      cancel() {
        this.$router.push('/projects');
      }
    }
  };
  </script>
  
  <style scoped>
  </style>