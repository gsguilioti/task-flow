<template>
    <div>
        <b-row no-gutters class="d-flex align-items-center p-3">
            <b-col md="11">
                <h1>Tasks</h1>
            </b-col>
            <b-col md="1">
                <b-button variant="success" class="me-2" @click="createTask">+ New</b-button>
            </b-col>
        </b-row>
    </div>
    <div v-for="(task, index) in this.tasks" :key="index">
        <b-card no-body class="overflow-hidden">
            <b-row no-gutters>
                <b-col md="10">
                    <b-card-body>
                        <b-card-text>
                            <h3>{{ task.name }}</h3>
                            <p> {{ task.projectName }} </p>
                            <p> {{ task.description }}</p>
                        </b-card-text>
                    </b-card-body>
                </b-col>
                <b-col md="2">
                    <b-card-body class="d-flex flex-row align-items-center h-100">
                        <b-button variant="primary" class="me-2" @click="editTask(task.id)">Edit</b-button>
                        <b-button variant="danger" @click="deleteTask(task.id)">Delete</b-button>
                    </b-card-body>
                </b-col>
            </b-row>
        </b-card>
    </div>
</template>
    
<script>
import TaskService from '@/services/TaskService';
import ProjectService from '@/services/ProjectService';

    export default {
      name: 'ListTask',
      data() {
        return {
            tasks: null
        };
      },
      created() {
        this.getTasks();
        for(let task in this.tasks)
            task.projectName = this.getProjectName(task.projectId)
     },
      methods: 
      {
        async getTasks()
        {
            try
            {
                const response = await TaskService.getAll();
                this.tasks = response.data;
            }
            catch(error)
            {
                console.error('Error fetching data:', error);
            }
        },
        editTask(id) {
            this.$router.push({ name: 'EditTask', params: { id } });
        },
        createTask() {
            this.$router.push({ name: 'NewTask'});
        },
        async deleteTask(id) {
            if(confirm(`Are you sure you want to delete the project ${id}?`))
            {
                await TaskService.delete(id);
                this.getTasks();
            }
            
        },
        async getProjectName(id) {
             await ProjectService.getById(id)
            .then((response) => {
                return response.data.name;
            } );
        }
      }
    };
</script>
    
<style scoped>

</style>