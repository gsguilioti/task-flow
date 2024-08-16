<template>
    <div>
      <b-card>
        <b-card-body>
          <h2>Edit Task</h2>
          <b-form @submit.prevent="updateTask">
            <b-form-group label="Name:" label-for="task-name">
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
    <div>
      <b-row no-gutters class="d-flex align-items-center p-3">
            <b-col md="11">
                <h1>Time Trackers</h1>
            </b-col>
            <b-col md="1">
                <b-button variant="success" class="me-2" @click="createTimeTracker">+ New</b-button>
            </b-col>
        </b-row>
    </div>
    <div v-for="(timeTracker, index) in this.timeTrackers" :key="index">
        <b-card no-body class="overflow-hidden">
            <b-row no-gutters>
                <b-col md="11">
                    <b-card-body>
                        <b-card-text>
                            <h3> Collaborator: {{ timeTracker.collaboratorId }} </h3>
                            <p> Time: {{ this.getHours(timeTracker.startDate, timeTracker.endDate) }} hours</p>
                        </b-card-text>
                    </b-card-body>
                </b-col>
                <b-col md="1">
                    <b-card-body class="d-flex flex-row align-items-center h-100">
                        <b-button variant="primary" class="me-2" @click="editTimeTracker(timeTracker.id)">Edit</b-button>
                    </b-card-body>
                </b-col>
            </b-row>
        </b-card>
    </div>
  </template>
  
  <script>
  import { useRoute } from 'vue-router';
  import TaskService from '@/services/TaskService';
  import ProjectService from '@/services/ProjectService';
  import TimeTrackerService from '@/services/TimeTrackerService';
  
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
        projects: [],
        timeTrackers: []
      };
    },
    created() {
      const route = useRoute();
      this.id = route.params.id;
      this.getProjects();
      this.getTimeTrackers(this.id);
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
      async getTimeTrackers(id) {
        try {
          const response = await TimeTrackerService.getByTask(id);
          this.timeTrackers = response.data;
        } catch (error) {
          console.error('Error fetching time trackers:', error);
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
      },
      createTimeTracker() {
            this.$router.push({ name: 'NewTimeTracker'});
      },
      editTimeTracker(id) {
            this.$router.push({ name: 'EditTimeTracker', params: { id } });
      },
      getHours(start, end) {
        const startDate = new Date(start);
        const endDate = new Date(end);

        const milliseconds = endDate - startDate;
        const millisecondsPerHour = 1000 * 60 * 60;
        const hours = milliseconds / millisecondsPerHour;
        
        return hours;
      },
    }
  };
  </script>
  
  <style scoped>
  </style>