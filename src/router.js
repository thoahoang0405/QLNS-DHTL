import { createRouter, createWebHistory } from "vue-router";
import Student from "./components/page/StudentManag.vue"
import Recruit from "./components/page/RecruitManag.vue";
import Document from "./components/page/ContractManag.vue";
import Employee from './components/page/EmployeeManag.vue'
import Bonus from "./components/page/BonusCis.vue";
import Home from "./components/page/HomePage.vue"
import Punish from './components/page/PunishPage.vue'
const routes =  [
    {
        
        path: "/",
        component: Home,
        
        children: [
            {
              path: "/sinhvien",
              component: Student,
            },
            {
              path: "/nhanvien",
              component: Employee,
            },
            {
              path: "/thuong",
              component: Bonus,
            },
            {
              path: "/kiluat",
              component: Punish,
            },
            {
              path: "/tuyendung",
              component: Recruit,
            },
            {
              path: "/hopdong",
              component: Document,
            },
            
          ],

    }
];
const router = createRouter({
    history: createWebHistory(),
    routes,
  });
  export default router;