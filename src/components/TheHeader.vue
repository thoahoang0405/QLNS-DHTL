<template>
    <div class="header">
        <div class="header-left">
        <h2>Quản lý nhân sự </h2>
      </div>
      <div class="header-right">
        <div class="h4">Hoàng Thị Thỏa</div>
        <div class="icon icon-user"></div>
        <div class="icon-down-bold" @click="showLogout" style="margin-left: 8px; cursor: pointer;"></div>
        <div class="drop-header" v-show="isLogout">
          <div class="logout" @click="logout">Đăng xuất</div>
        </div>
      </div>
    </div>
</template>
<style scoped>
@import url(../css/main.css);
@import url(../css/page/header.css);
.drop-header{
  position: absolute;
  width: 100px;
  height:36px;
  background-color: #ffff;
  
  z-index: 10;
  right: 5px;
    top: 46px;
    align-items: center;
}
.logout{
width: 100%;
height: 36px;
align-items: center;
display: flex;
    justify-content: center;
    border: 1px solid #ccc;
    cursor: pointer;
}
.logout:hover{
  background-color:#bfe2fa;
}
</style>
<script>
import axios from "axios"
export default{
  data(){
    return{
      isLogout: false,
    }
  },
  methods: {
    showLogout(){
      this.isLogout=!this.isLogout
      
    },
    logout(){
      localStorage.removeItem("Token");
      axios.defaults.headers.common["Authorization"] = null;
      this.$router.push("/login");
    }
  }
  
}
</script>
