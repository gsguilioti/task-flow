<template>
    <div>
      <b-card>
        <b-card-body>
          <h2>New Project</h2>
          <b-form @submit.prevent="createProject">
            <b-form-group label="Project Name:" label-for="project-name">
              <b-form-input
                id="project-name"
                v-model="project.name"
                required
              ></b-form-input>
            </b-form-group>
            
            <b-form-group label="Project Description:" label-for="project-description">
              <b-form-textarea
                id="project-description"
                v-model="project.description"
                rows="3"
                required
              ></b-form-textarea>
            </b-form-group>
            
            <b-button type="submit" variant="success">Create</b-button>
            <b-button @click="cancel" variant="secondary" class="ms-2">Cancel</b-button>
          </b-form>
        </b-card-body>
      </b-card>
    </div>
  </template>
  
  <script>
  import { ref } from 'vue';
  import ProjectService from '@/services/ProjectService';
  import { useRouter } from 'vue-router';
  
  export default {
    name: 'NewProject',
    setup() {
      const router = useRouter();
      
      const project = ref({
        name: '',
        description: ''
      });
  
      const createProject = async () => {
        try {
          await ProjectService.create(project.value);
          router.push('/projects');
        } catch (error) {
          console.error('Error creating project:', error);
        }
      };
  
      const cancel = () => {
        router.push('/projects');
      };
  
      return {
        project,
        createProject,
        cancel
      };
    }
  };
  </script>
  
  <style scoped>
  </style>