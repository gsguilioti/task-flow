<template>
    <div>
      <b-card>
        <b-card-body>
          <h2>Edit Collaborador</h2>
          <b-form @submit.prevent="updateCollaborator">
            <b-form-group label="Collaborator Name:" label-for="collaborator-name">
              <b-form-input
                id="collaborator-name"
                v-model="collaborator.name"
                required
              >{{ this.collaborator.name }}</b-form-input>
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
  import CollaboratorService from '@/services/CollaboratorService';
  
  export default {
    name: 'EditCollaborator',
    data() {
      return {
        collaborator: {
          name: ''
        },
        id: null
      };
    },
    created() {
      const route = useRoute();
      this.id = route.params.id;
      this.getCollaborator();
    },
    methods: {
      async getCollaborator() {
        try {
          const response = await CollaboratorService.getById(this.id);
          this.collaborator = response.data;
        } catch (error) {
          console.error('Error fetching collaborator data:', error);
        }
      },
      async updateCollaborator() {
        try {
          await CollaboratorService.update(this.id, this.collaborator);
          this.$router.push('/collaborators');
        } catch (error) {
          console.error('Error updating collaborator:', error);
        }
      },
      cancel() {
        this.$router.push('/collaborators');
      }
    }
  };
  </script>
  
  <style scoped>
  </style>