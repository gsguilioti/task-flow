<template>
    <div>
      <b-card>
        <b-card-body>
          <h2>Edit Task</h2>
          <b-form @submit.prevent="updateTask">
            <b-form-group label="Task Name:" label-for="task-name">
              <b-form-input
                id="task-name"
                v-model="task.name"
                required
              >{{ this.task.name }}</b-form-input>
            </b-form-group>

            <b-form-group label="Description:" label-for="task-description">
              <b-form-textarea
                id="task-description"
                v-model="task.description"
                rows="3"
              ></b-form-textarea>
            </b-form-group>

            <b-form-group label="Project:" label-for="task-project">
              <b-form-select
                id="task-project"
                v-model="task.projectId"
              >
                <option v-for="project in this.projects" :key="project.id" :value="project.id">
                  {{ project.name }}
                </option>
              </b-form-select>
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
  import TaskService from '@/services/TaskService';
  import ProjectService from '@/services/ProjectService';
  
  export default {
    name: 'EditTask',
    data() {
      return {
        task: {
          name: '',
          description: '',
          projectId: ''
        },
        id: null,
        projects: []
      };
    },
    created() {
      const route = useRoute();
      this.id = route.params.id;
      this.getProjects();
      this.getTask();
    },
    methods: {
      async getProjects() {
        try {
          const response = await ProjectService.getAll();
          this.projects = response.data;
        } catch (error) {
          console.error('Error fetching projects:', error);
       }
      },
      async getTask() {
        try {
          const response = await TaskService.getById(this.id);
          this.task = response.data;
        } catch (error) {
          console.error('Error fetching task data:', error);
        }
      },
      async updateTask() {
        try {
          await TaskService.update(this.id, this.task);
          this.$router.push('/tasks');
        } catch (error) {
          console.error('Error updating task:', error);
        }
      },
      cancel() {
        this.$router.push('/tasks');
      }
    }
  };
  </script>
  
  <style scoped>
  </style>