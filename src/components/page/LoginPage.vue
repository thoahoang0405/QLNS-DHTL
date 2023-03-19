<template>
  <div class="login">
    <div class="login-content">
      <div class="login-content-image"></div>
      <div class="login-content-form">
        <div class="logo">
          <img src="../../assets/img/Logo-DH-Thuy-Loi.webp" alt="" />
        </div>
        <div class="text"> <span>Quản Lý Nhân Sự</span></div>
        <input placeholder="Tên đăng nhập" type="text" v-model="userName" />

        <input placeholder="Mật khẩu" type="password" v-model="password" />

        <button @click="onClickLogin" class="btnLogin">Đăng nhập</button>

        <router-link to="/sinhvien">Quên mật khẩu?</router-link>

        <div v-if="errorLogin !== ''" class="error-login">{{ errorLogin }}</div>
      </div>
    </div>
    <div class="login-footer">footer</div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  created() {},
  data() {
    return {
      password: "",
      userName: "",
      reload: true,
      errorLogin: "",
    };
  },
  methods: {
    async onClickLogin() {
      const response = await axios({
        url: "https://localhost:44301/api/Authors/sign-in",
        method: "Post",
        data: {
          userName: this.userName,
          password: this.password,
        },
      }).catch(() => {
        this.errorLogin = "Tài khoản hoặc mật khẩu không chính xác!";
      });

      console.log(response);
      localStorage.setItem("Token", response.data);
      axios.defaults.headers.common["Authorization"] =
        "Bearer " + localStorage.getItem("Token");
      this.$router.push("/sinhvien");
    },
  },
};
</script>


<style scoped>
input{
  border: 1px solid #161414;
  outline-color: #8fde;
}
input:focus{
  outline-color: #8fde;
}
.btnLogin:hover{
background-color: #fff;
color: #1a73e8;
border: 1px solid #1a73e8;
}
@import url("../../css/page/login.css");
</style>
