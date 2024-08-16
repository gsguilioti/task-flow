import { createRouter, createWebHistory } from 'vue-router';
import Login from './views/Login.vue';
import ListProject from './components/ListProject.vue';
import ListTasks from './components/ListTasks.vue';
import ListCollaborator from './components/ListCollaborator.vue';
import EditProject from './components/EditProject.vue';
import NewProject from './components/NewProject.vue';
import EditCollaborator from './components/EditCollaborator.vue';
import NewTask from './components/NewTask.vue';
import EditTask from './components/EditTask.vue';

const routes = [
  {
    path: '/',
    redirect: '/login'
  },
  {
    path: '/projects',
    name: 'Projects',
    component: ListProject
  },
  {
    path: '/projects/edit/:id',
    name: 'EditProject',
    component: EditProject,
    props: true
  },
  {
    path: '/projects/new',
    name: 'NewProject',
    component: NewProject,
  },
  {
    path: '/tasks',
    name: 'Tasks',
    component: ListTasks
  },
  {
    path: '/tasks/edit/:id',
    name: 'EditTask',
    component: EditTask,
  },
  {
    path: '/tasks/new',
    name: 'NewTask',
    component: NewTask,
  },
  {
    path: '/collaborators',
    name: 'Collaborators',
    component: ListCollaborator
  },
  {
    path: '/collaborators/edit/:id',
    name: 'EditCollaborator',
    component: EditCollaborator,
    props: true
  },
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;