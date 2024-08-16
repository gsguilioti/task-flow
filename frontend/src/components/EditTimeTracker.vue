<template>
    <div>
      <b-card>
        <b-card-body>
          <h2>Edit TimeTracker</h2>
          <b-form @submit.prevent="updateTimeTracker">
            <b-form-group label="Start Date:" label-for="timeTracker-startDate">
              <input 
                type="datetime-local"
                id="timeTracker-startDate"
                v-model="this.timeTracker.startDate"
                required
              />
            </b-form-group>
            
            <b-form-group label="End Date:" label-for="timeTracker-endDate">
              <input
                type="datetime-local"
                id="timeTracker-endDate"
                v-model="this.timeTracker.endDate"
                required
              />
            </b-form-group>

            <b-form-group label="Task:" label-for="timeTracker-task">
              <b-form-input
                id="timeTracker-task"
                v-model="this.timeTracker.taskId"
                disabled
              >
              {{ this.timeTracker.taskId }}
              </b-form-input>
            </b-form-group>

            <b-form-group label="Collaborator:" label-for="timeTracker-collaborator">
              <b-form-select
                id="timeTracker-collaborator"
                v-model="this.timeTracker.collaboratorId"
              >
                <option v-for="collaborator in this.collaborators" :key="collaborator.id" :value="this.timeTracker.collaboratorId">
                  {{ collaborator.name }}
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
  import TimeTrackerService from '@/services/TimeTrackerService';
  import CollaboratorService from '@/services/CollaboratorService';
  
  export default {
    name: 'EditTimeTracker',
    data() {
      return {
        timeTracker: {
        },
        id: null,
        collaborators: []
      };
    },
    created() {
      const route = useRoute();
      this.id = route.params.id;
      this.getTimeTracker();
      this.getCollaborators();
    },
    methods: {
      async getCollaborators() {
        try {
          const response = await CollaboratorService.getAll();
          this.collaborators = response.data;
        } catch (error) {
          console.error('Error fetching collaborators data:', error);
        }
      },
      async getTimeTracker() {
        try {
          const response = await TimeTrackerService.getById(this.id);
          this.timeTracker = response.data;

        } catch (error) {
          console.error('Error fetching time tracker data:', error);
        }
      },
      async updateTimeTracker() {
        try {
          await TimeTrackerService.update(this.id, this.timeTracker);
          this.$router.push('/timeTrackers');
        } catch (error) {
          console.error('Error updating time tracker:', error);
        }
      },
      cancel() {
        this.$router.push({ name: 'EditTask', params: { id: this.timeTracker.taskId } });
      }
    }
  };
  </script>
  
  <style scoped>
  </style>