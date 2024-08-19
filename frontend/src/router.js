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
import NewTimeTracker from './components/NewTimeTracker.vue';
import EditTimeTracker from './components/EditTimeTracker.vue';

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
    component: NewProject
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
    path: '/timetracker/edit/:id',
    name: 'EditTimeTracker',
    component: EditTimeTracker,
    props: true
  },
  {
    path: '/timetracker/new',
    name: 'NewTimeTracker',
    component: NewTimeTracker,
  },
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
  {
    path: '/:catchAll(.*)',
    redirect: '/login'
  }
];

const authRoutes = routes.map(route => {
  if (route.name !== 'Login') {
    return {
      ...route,
      meta: { requiresAuth: true }
    };
  }
  return route;
});

const router = createRouter({
  history: createWebHistory(),
  routes: authRoutes
});

router.beforeEach((to, from, next) => {
  const isAuthenticated = !!localStorage.getItem('token');
  
  if (to.matched.some(record => record.meta.requiresAuth) && !isAuthenticated) {
    next('/login');
  } else {
    next();
  }
});

export default router;