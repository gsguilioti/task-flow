<template>
    <div>
      <b-card>
        <b-card-body>
          <h2>New Task</h2>
          <b-form @submit.prevent="createTask">
            <b-form-group label="Task Name:" label-for="task-name">
              <b-form-input
                id="task-name"
                v-model="task.name"
                required
              ></b-form-input>
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
              >
                <option v-for="project in projects" :key="project.id" :value="project.id">
                  {{ project.name }}
                </option>
              </b-form-select>
            </b-form-group>
            
            <b-button type="submit" variant="success" @click="createTask">Create</b-button>
            <b-button @click="cancel" variant="secondary" class="ms-2">Cancel</b-button>
          </b-form>
        </b-card-body>
      </b-card>
    </div>
  </template>
  
  <script>
  import { ref, onMounted } from 'vue';
  import TaskService from '@/services/TaskService';
  import ProjectService from '@/services/ProjectService';
  import { useRouter } from 'vue-router';
  
  export default {
    name: 'NewTask',
    setup() {
      const router = useRouter();
      const task = ref({
        name: '',
        description: ''
      });

      const projects = ref([]);

      const getProjects = async () => {
        try {
          const response = await ProjectService.getAll();
          projects.value = response.data;
        } catch (error) {
          console.error('Error fetching projects:', error);
      }
    };
  
      const createTask = async () => {
        try {
          await TaskService.create(task.value);
          router.push('/tasks');
        } catch (error) {
          console.error('Error creating task:', error);
        }
      };
  
      const cancel = () => {
        router.push('/tasks');
      };

      onMounted(() => {
        getProjects();
      });
  
      return {
        task,
        projects,
        createTask,
        cancel
      };
    }
  };
  </script>
  
  <style scoped>
  </style>