<template>
    <div>
      <b-card>
        <b-card-body>
          <h2>New TimeTracker</h2>
          <b-form @submit.prevent="createTimeTracker">
            <b-form-group label="Start Date:" label-for="timeTracker-startDate">
              <input 
                type="datetime-local"
                id="timeTracker-startDate"
                v-model="timeTracker.startDate"
                required
              />
            </b-form-group>
            
            <b-form-group label="End Date:" label-for="timeTracker-endDate">
              <input
                type="datetime-local"
                id="timeTracker-endDate"
                v-model="timeTracker.endDate"
                required
              />
            </b-form-group>

            <b-form-group label="Task:" label-for="timeTracker-task">
              <b-form-select
                id="timeTracker-task"
                v-model="timeTracker.taskId"
              >
                <option v-for="task in tasks" :key="task.id" :value="task.id">
                  {{ task.name }}
                </option>
              </b-form-select>
            </b-form-group>

            <b-form-group label="Collaborator:" label-for="timeTracker-collaborator">
              <b-form-select
                id="timeTracker-collaborator"
                v-model="timeTracker.collaboratorId"
              >
                <option v-for="collaborator in collaborators" :key="collaborator.id" :value="collaborator.id">
                  {{ collaborator.name }}
                </option>
              </b-form-select>
            </b-form-group>
            
            <b-button type="submit" variant="success">Create</b-button>
            <b-button @click="cancel" variant="secondary" class="ms-2">Cancel</b-button>
          </b-form>
        </b-card-body>
      </b-card>
    </div>
  </template>
  
  <script>
  import { ref, onMounted } from 'vue';
  import { useRouter } from 'vue-router';
  import TimeTrackerService from '@/services/TimeTrackerService';
  import TaskService from '@/services/TaskService';
  import CollaboratorService from '@/services/CollaboratorService';
  
  export default {
    name: 'NewTimeTracker',
    setup() {
      const router = useRouter();
      const timeTracker = ref({
      });

      const tasks = ref([]);
      const collaborators = ref([]);

      const getTasks = async () => {
        try {
          const response = await TaskService.getAll();
          tasks.value = response.data;
        } catch (error) {
          console.error('Error fetching tasks:', error);
        }
      };

      const getCollaborators = async () => {
        try {
          const response = await CollaboratorService.getAll();
          collaborators.value = response.data;
        } catch (error) {
          console.error('Error fetching collaborators:', error);
        }
      };
  
      const createTimeTracker = async () => {
        try {
          await TimeTrackerService.create(timeTracker.value);
          router.push('/tasks');
        } catch (error) {
          console.error('Error creating time tracker:', error);
        }
      };
  
      const cancel = () => {
        router.push('/tasks');
      };

      onMounted(() => {
        getTasks();
        getCollaborators();
      });
  
      return {
        timeTracker,
        tasks,
        collaborators,
        createTimeTracker,
        cancel
      };
    }
  };
  </script>
  
  <style scoped>
  </style>