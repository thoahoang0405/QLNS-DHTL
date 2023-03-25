import { createRouter, createWebHistory } from "vue-router";

import Recruit from "./components/page/RecruitManag.vue";
import Document from "./components/page/ContractManag.vue";
import Employee from './components/page/EmployeeManag.vue'
import Bonus from "./components/page/BonusCis.vue";
import Home from "./components/page/HomePage.vue"
import LoginPage from "../src/components/page/LoginPage.vue";
import Axios from "axios";
import Education from "./components/page/EducationManag.vue";


const routes =  [
  {
    path: "/login",
    component: LoginPage,
  },
    {
        
        path: "/",
        component: Home,
        
        children: [
          {
            path: "/nhanvien",
            component: Employee,
          },
         
            {
              path: "/thuong",
              component: Bonus,
            },
            {
              path: "/tuyendung",
              component: Recruit,
            },
            {
              path: "/hopdong",
              component: Document,
            },
            {
              path: "/hocvan",
              component: Education,
            },
            
          ],

    }
];
const router = createRouter({
    history: createWebHistory(),
    routes,
  });
  router.beforeEach(async (to) => {
    if (to.fullPath == "/login") return true;
  
    const response = await Axios({
      url: "https://localhost:44301/api/Authors",
      method: "Get",
    }).catch(() => {
      return null;
    });
  
    if (!response) return "/login";
  });
  
  export default router;