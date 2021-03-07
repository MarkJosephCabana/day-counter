import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import TaskOne from '../views/TaskOne.vue'
import TaskTwo from '../views/TaskTwo.vue'
import TaskThree from '../views/TaskThree.vue'
import NotFound from '../views/NotFound.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/task/1',
    name: 'TaskOne',
    component: TaskOne
  }, {
    path: '/task/2',
    name: 'TaskTwo',
    component: TaskTwo
  }, {
    path: '/task/3',
    name: 'TaskThree',
    component: TaskThree
  },{
    path: '*',
    name: 'NotFound',
    component: NotFound
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
