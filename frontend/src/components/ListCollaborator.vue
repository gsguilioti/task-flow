<template>
    <div>
        <b-row no-gutters class="d-flex align-items-center p-3">
            <h1>Collaborators</h1>
        </b-row>
    </div>
    <div v-for="(collaborator, index) in this.collaborators" :key="index">
        <b-card no-body class="overflow-hidden">
            <b-row no-gutters>
                <b-col md="10">
                    <b-card-body>
                        <b-card-text>
                            {{ collaborator.name }}
                        </b-card-text>
                    </b-card-body>
                </b-col>
                <b-col md="2">
                    <b-card-body class="d-flex">
                        <b-button variant="primary" class="me-2" @click="editCollaborator(collaborator.id)">Edit</b-button>
                        <b-button variant="danger" @click="deleteCollaborator(collaborator.id)">Delete</b-button>
                    </b-card-body>
                </b-col>
            </b-row>
        </b-card>
    </div>
</template>

<script>
import CollaboratorService from '@/services/CollaboratorService';

    export default {
      name: 'ListCollaborator',
      data() {
        return {
            collaborators: null
        };
      },
      created() {
        this.getCollaborators();
     },
      methods: 
      {
        async getCollaborators()
        {
            try
            {
                const response = await CollaboratorService.getAll();
                this.collaborators = response.data;
            }
            catch(error)
            {
                console.error('Error fetching data:', error);
            }
        },
        editCollaborator(id) {
            this.$router.push({ name: 'EditCollaborator', params: { id } });
        },
        async deleteCollaborator(id) {
            if(confirm(`Are you sure you want to delete the project ${id}?`))
            {
                await CollaboratorService.delete(id);
                this.getCollaborators();
            }
            
        }
      }
    };
</script>
    
<style scoped>

</style>