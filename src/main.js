import { createApp } from 'vue'
import App from './App.vue'
import router from "./router";
// import 'boostsrap/dict/css/bootstrap-grid.min.css'
// import 'boostsrap/dict/css/bootstrap-utilities.min.css'
// import '../node_modules/bootstrap/dist/css/bootstrap-grid.min.css'
// import '../node_modules/bootstrap/dist/css/bootstrap-utilities.min.css'
const app =createApp(App)
app.use(router);
app.mount("#app");