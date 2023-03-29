<template>
  <div class="login" >
    <div class="login-content" >
      <div class="login-content-image"></div>
      <div class="login-content-form" @keypress.enter="onClickLogin">
        <div class="logo">
          <img src="../../assets/img/Logo-DH-Thuy-Loi.webp" alt="" />
        </div>
        <div class="text"> <span>Quản Lý Nhân Sự</span></div>
        <label for=""> Tên đăng nhập</label>
        <input :class="errorUser!=''? 'borderRed' : ''" required placeholder="Tên đăng nhập" @blur="validateUser" type="text" v-model="userName" />
        <div v-if="errorUser!=''" style="color: red; position: absolute; margin-top: -26px;" class="error">{{ errorUser }}</div>
        <label for=""> Mật khẩu</label>
        <input :class="errorPass!=''? 'borderRed' : ''" @blur="validatePass" required placeholder="Mật khẩu" type="password" v-model="password" />
        <div v-if="errorPass!=''" style="color: red; position: absolute; margin-top: -26px;" class="error">Mật khẩu không được trống</div>
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
      errorUser:"",
      errorPass:"",
    };
  },
  methods: {
    validateUser(){
      if(this.userName == ''){
        console.log(1);
        this.errorUser="Tên đăng nhập không được trống"
      }else{
        this.errorUser=""
      }
    },
    validatePass(){
      if(this.password == ''){
        
        this.errorPass="Mật khẩu không được trống"
      }else{
        this.errorPass=""
      }
    },
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
      this.$router.push("/nhanvien");
    },
  },
};
</script>


<style scoped>
label{
  font-size: 15px;
}
input{
  border: 1px solid #161414;
  outline-color: #8fde;
  margin-top: 8px;
}
input:focus{
  outline-color: #8fde;
  border: 1px solid rgb(58, 230, 81);
}
.btnLogin:hover{
background-color: #fff;
color: #000;
border: 1px solid #000;
}
.borderRed{
  border: 1px solid red;
}
@import url("../../css/page/login.css");
</style>
