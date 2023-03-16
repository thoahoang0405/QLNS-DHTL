<template>
    <div id="form">
       <form class="form">
           <div class="form-top">
               <div class="form-title">
                   <h3 class="title">Thêm/sửa thông tin nhân viên</h3>
                   <span class="close" @click="closeForm">X</span>
               </div>
           </div>
           <div class="form-Wrap">
               <div class="column">
                   <div class="input__box">
                       <label for="">Mã nhân viên</label>
                       <input class="manv" type="text" v-model="desc.manv">
                       <div class="invalid-feedback" v-if="errors.manv">{{ errors.manv }}</div>
                   </div>
                   <div class="input__box">
                       <label for="">Tên nhân viên</label>
                       <input class="ten" type="text" v-model="desc.ten">
                       <div class="invalid-feedback" v-if="errors.ten">{{ errors.ten }}</div>
                   </div>
                   <div class="input__box">
                       <label for="">Giới tính</label>
                       <div class="radio__box">
                           <input type="radio" id="nam" v-model="desc.gioitinh" value="nam">
                           <label class="nam" for="">Nam</label>
                           <input type="radio" id="nu" v-model="desc.gioitinh" value="nu">
                           <label class="nu" for="">Nữ</label>
                       </div>
                       <!-- <div style= "color:red" id="disp">{{ desc.gioitinh }}</div> -->
                   </div>
               </div>
               
               <div class="column">
                   <div class="input__box">
                       <label for="">Ngày sinh</label>
                       <input class="ngaysinh" type="date" v-model="desc.ngaysinh">
                       <div class="invalid-feedback" v-if="errors.ngaysinh">{{ errors.ngaysinh }}</div>
                   </div>
                   <div class="input__box">
                       <label for="">Khoa</label>
                       <combobox  class="khoa " :value="desc.khoa" :items="dataItem" :code="'id'" :fieldName="'khoa'" @selectedItem="selectItemCbb"></combobox>
                       <!-- <input class="khoa" type="text" v-model="desc.khoa"> -->
                      
                   </div>
               </div>
               <div class="column">
                    <div class="input__box">
                        <label for="">Cmnd/cccd</label> 
                        <input class="cmnd" type="text" v-model="desc.cmnd">
                        <div class="invalid-feedback" v-if="errors.cmnd">{{ errors.cmnd }}</div>
                    </div>
                    <div class="input__box">
                        <label for="">Ngày cấp</label>
                        <input class="ngaycap" type="date" v-model="desc.ngaycap">
                        <div class="invalid-feedback" v-if="errors.ngaycap">{{ errors.ngaycap }}</div>
                    </div>
                    <div class="input__box">
                        <label for="">Nơi cấp</label>
                    <input class="noicap" type="text" v-model="desc.noicap">
                    <div class="invalid-feedback" v-if="errors.noicap">{{ errors.noicap }}</div>
                    </div>
                </div>
               
               <div class="column">
                   <div class="input__box">
                       <label for="">Email</label>
                       <input class="email" type="text" v-model="desc.email">
                       <div class="invalid-feedback" v-if="errors.email">{{ errors.email }}</div>
                   </div>
                   <div class="input__box">
                       <label for="">Số điện thoại</label>
                       <input class="sodt" type="text" v-model="desc.sodt">
                       <div class="invalid-feedback" v-if="errors.sodt">{{ errors.sodt }}</div>
                   </div>
               </div>
               <div class="column column-s">
                   <div class="input__box">
                       <label for="">Mã số thuế</label>
                       <input class="masothue" type="text" v-model="desc.masothue">
                       <div class="invalid-feedback" v-if="errors.masothue">{{ errors.masothue }}</div>
                   </div>
                   <div class="input__box">
                       <label for="">Số tài khoản</label>
                       <input class="sotaikhoan" type="text" v-model="desc.sotaikhoan">
                       <div class="invalid-feedback" v-if="errors.sotaikhoan">{{ errors.sotaikhoan }}</div>
                   </div>
                   <div class="input__box">
                       <label for="">Tên ngân hàng</label>
                       <input class="tennganhang" type="text" v-model="desc.tennganhang">
                       <div class="invalid-feedback" v-if="errors.tennganhang">{{ errors.tennganhang }}</div>
                   </div>

               </div>
               <div class="input__box">    
                   <label for="">Địa chỉ</label>
                   <input class="diachi" type="text" v-model="desc.diachi">
                   <div class="invalid-feedback" v-if="errors.diachi">{{ errors.diachi }}</div>
               </div>
               <div class="column column-s">
                   <div class="input__box">
                       <label for="">Trạng thái</label>
                       <input class="trangthai" type="text" v-model="desc.trangthai">
                       <div class="invalid-feedback" v-if="errors.trangthai">{{ errors.trangthai }}</div>
                   </div>
                   <div class="input__box">
                       <label for="">Cấp bậc lương</label>
                       <input class="capbacluong" type="text" v-model="desc.capbacluong">
                       <div class="invalid-feedback" v-if="errors.capbacluong">{{ errors.capbacluong }}</div>
                   </div>

               </div>
               
               <div class="column column-s">
                   <div class="input__box">
                       <label for="">Phòng ban</label>
                       <input class="phongban" type="text" v-model="desc.phongban">
                       <div class="invalid-feedback" v-if="errors.phongban">{{ errors.phongban }}</div>
                   </div>
                   <div class="input__box">
                       <label for="">Chứng chỉ đào tạo</label>
                       <input class="daotao" type="text" v-model="desc.daotao">
                       <div class="invalid-feedback" v-if="errors.daotao">{{ errors.daotao }}</div>
                   </div>
                   <div class="input__box">
                       <label for="">Tình trạng hôn nhân</label>
                       <input class="tinhtrang" type="text" v-model="desc.tinhtrang">
                       <div class="invalid-feedback" v-if="errors.tinhtrang">{{ errors.tinhtrang }}</div>
                   </div>
               </div>
               <div class="column">
                   <div class="input__box">
                       <label for="">Khen thưởng</label>
                       <input class="khenthuong" type="text" v-model="desc.khenthuong">
                       <div class="invalid-feedback" v-if="errors.khenthuong">{{ errors.khenthuong }}</div>
                   </div>
                   <div class="input__box">
                       <label for="">Kỷ luật</label>
                       <input class="kyluat" type="text" v-model="desc.kyluat">
                       <div class="invalid-feedback" v-if="errors.kyluat">{{ errors.kyluat }}</div>
                   </div>
               </div>
           </div>
           <div class="form-bottom">
               <div class="btn btn-cancel" @click="closeForm">Hủy</div>
               <div class="btn btn-save" @click="save()" >Lưu</div>
           </div>
       </form>
   </div>

   <!-- thongbao -->
   <notifi v-show="isShowNotifi" @closeNotifi="closeNo" @cancelNotifi="FormCancel"></notifi>
   
</template>
<style>

label {
    margin: 14px 0;
}
.invalid-feedback {
   color: red;
   position: absolute;
   font-size: 12px;
   /* border: 2px solid red; */
}
#form {
   background-color: rgba(0, 0, 0, 0.2);
   z-index: 3;
   width: 100%;
   height: 100%;
   margin: auto;
   position: fixed;
   display: flex;
   /* display: none; */
 }
 input {
    padding-bottom: 6px;
    max-width: 100%;
    max-height: 20px;
   border: 1px solid #ccc;
   border-radius: 2px;
   outline: none;
   height: 10px;
   position: relative;
   height: 29px;
   width: 100%;
   outline: none;
   padding-left: 5px;
   color: #707070;
   margin-top: 7px;
 }
 .form {
   width: fit-content;
   height: fit-content;
   background-color: #fff;
   margin: auto auto;
   border-radius: 8px;
   width:800px;
   /* display: none; */
}
.form-Wrap {
    padding: 0 20px;
}
.form-title {
    padding: 0 13px;
    background-color: #D9D9D9;
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 14px;
}
.close {
    cursor: pointer;
    font-weight: 600;
    font-size: 18px;
    color: #726c6c;
}
 .input__box {
   width: 100%;
   margin-bottom: 10px;
 }
 .form-bottom {
   display: flex;
   justify-content: flex-end;
   padding: 14px;
   background-color: #D9D9D9;
   gap: 28px;
   margin-top: 14px;
 }
 .btn-cancel {
   background-color: #fff;
 }
 .btn-save {
   background-color:  #1A8FDD;
   color: #fff;
}
.btn {
   padding: 10px 30px;
   cursor: pointer;
   border-radius: 2px;
   height: 36px;
   align-items: center;
   box-sizing: border-box;
 }
 .column {
   display: flex;
   column-gap: 20px;
 }
 .radio__box {
   display: flex;
   align-items: center;
   margin-top: 8px;
   column-gap: 10px;
 }
 .radio__box input {
   width: 15px;
   margin: 0;
 }
 /* @media screen and (max-width: 520px) {
  .column-s{
   display: block;
  }
  .column {
   margin-bottom: 0;
  }
  label {
   font-size: 12px;
  }
  input {
   font-size: 12px;
   height: 20px;   
  }
 } */
</style>
<script>
import notifi from "./FormNotifi.vue"
import combobox from "../base/BaseCombobox.vue";
   export default {
       data(){
           return {
                isShowNotifi: false,
                dataItem:[
                    {id:1, khoa: 'CNTT'},
                    {id:2, khoa: 'QTKD'},
                    {id:3, khoa: 'Kinh tế'},
                    {id:4, khoa: 'Cơ Khí'}
                ],
                dataFields: {value: 'id', text: 'khoa'},
               isShow: false,
               errors: {
                   manv: '',
                   ten: '',
                   ngaysinh: '',
                   khoa: '',
                   cmnd: '',
                   ngaycap: '',
                   noicap: '',
                   email: '',
                   sodt: '',
                   masothue: '',
                   sotaikhoan: '',
                   tennganhang: '',
                   trangthai: '',
                   capbacluong: '',
                   phongban: '',
                   tinhtrang: '',
                   diachi: '',
                   daotao: '',
                   khenthuong: '',
                   kyluat: '',
               },
               desc: {
                manv: '',
                   ten: '',
                   ngaysinh: '',
                   khoa: '',
                   cmnd: '',
                   ngaycap: '',
                   noicap: '',
                   email: '',
                   sodt: '',
                   masothue: '',
                   sotaikhoan: '',
                   tennganhang: '',
                   trangthai: '',
                   capbacluong: '',
                   phongban: '',
                   tinhtrang: '',
                   diachi: '',
                   daotao: '',
                   khenthuong: '',
                   kyluat: '',
               }
           }
       },
       components: {
           combobox,
           notifi
       },
       methods: {
            selectItemCbb(value) {
                this.desc.khoa = value.khoa
            },
           btnHidden(){
               this.isShow = !this.isShow
           },
           closeNo(value) {
                this.isShowNotifi = value;
            },
            FormCancel(value) {
                this.isShowNotifi = value
                this.$emit("hideForm", false);
            },
            
           //gửi lệnh ẩn form từ bên này sang trang chính
           closeForm(){
                this.isShowNotifi = true
            //    this.$emit("hideForm", false);
               this.desc = {
                manv: '',
                   ten: '',
                   ngaysinh: '',
                   khoa: '',
                   cmnd: '',
                   ngaycap: '',
                   noicap: '',
                   email: '',
                   sodt: '',
                   masothue: '',
                   sotaikhoan: '',
                   tennganhang: '',
                   trangthai: '',
                   capbacluong: '',
                   phongban: '',
                   tinhtrang: '',
                   diachi: '',
                   daotao: '',
                   khenthuong: '',
                   kyluat: '',
               }
               this.errors = {
                manv: '',
                   ten: '',
                   ngaysinh: '',
                   khoa: '',
                   cmnd: '',
                   ngaycap: '',
                   noicap: '',
                   email: '',
                   sodt: '',
                   masothue: '',
                   sotaikhoan: '',
                   tennganhang: '',
                   trangthai: '',
                   capbacluong: '',
                   phongban: '',
                   tinhtrang: '',
                   diachi: '',
                   daotao: '',
                   khenthuong: '',
                   kyluat: '',
               }
           },
           validate(){
               let isValid = true;

               this.errors = {
                   manv: '',
                   ten: '',
                   ngaysinh: '',
                   khoa: '',
                   cmnd: '',
                   ngaycap: '',
                   noicap: '',
                   email: '',
                   sodt: '',
                   masothue: '',
                   sotaikhoan: '',
                   tennganhang: '',
                   trangthai: '',
                   capbacluong: '',
                   phongban: '',
                   tinhtrang: '',
                   diachi: '',
                   daotao: '',
                   khenthuong: '',
                   kyluat: '',
               }
               if(!this.desc.manv) {
                   this.errors.manv = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.ten) {
                   this.errors.ten = "Không được để trống!";
                   isValid = false;
               }
               // if(!this.desc.gioitinh) {
               //     this.errors.gioitinh = "Không được để trống!";
               //     isValid = false;
               // }
               if(!this.desc.ngaysinh) {
                   this.errors.ngaysinh = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.sodt) {
                   this.errors.sodt = "Không được để trống!";
                   isValid = false;
               } else if(!this.isNumber(this.desc.sodt)) {
                   this.errors.sodt = "Yêu cầu nhập số";
                   isValid = false;
               }
               if(!this.desc.khoa) {
                   this.errors.khoa = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.cmnd) {
                   this.errors.cmnd = "Không được để trống!";
                   isValid = false;
               }else if(!this.isNumber(this.desc.cmnd)) {
                   this.errors.cmnd = "Yêu cầu nhập số";
                   isValid = false;
               }
               if(!this.desc.masothue) {
                   this.errors.masothue = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.sotaikhoan) {
                   this.errors.sotaikhoan = "Không được để trống!";
                   isValid = false;
               } else if(!this.isNumber(this.desc.sotaikhoan)) {
                   this.errors.sotaikhoan = "Yêu cầu nhập số";
                   isValid = false;
               }
               if(!this.desc.email) {
                   this.errors.email = "Không được để trống!";
                   isValid = false;
               }else if(!this.isEmail(this.desc.email)) {
                   this.errors.email = "Yêu cầu nhập kiểu email";
                   isValid = false;
               }
               if(!this.desc.diachi) {
                   this.errors.diachi = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.daotao) {
                   this.errors.daotao = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.tennganhang) {
                   this.errors.tennganhang = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.trangthai) {
                   this.errors.trangthai = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.capbacluong) {
                   this.errors.capbacluong = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.phongban) {
                   this.errors.phongban = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.tinhtrang) {
                   this.errors.tinhtrang = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.khenthuong) {
                   this.errors.khenthuong = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.kyluat) {
                   this.errors.kyluat = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.ngaycap) {
                   this.errors.ngaycap = "Không được để trống!";
                   isValid = false;
               }
               if(!this.desc.noicap) {
                   this.errors.noicap = "Không được để trống!";
                   isValid = false;
               }


               // var getSelectedValue = document.querySelector( 
               //     'input[name="gioitinh"]:checked'); 
           
               // if(getSelectedValue != null) { 
               //     document.getElementById("disp").innerHTML 
               //         = getSelectedValue.value 
               //         + " season is selected"; 
               // }
               
               return isValid
           },
           isNumber(value) {
               return /^\d*$/.test(value);
           },
           isEmail(value){
               var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
               return validRegex.test(value)
           },
           save(){
               this.validate()
            //    console.log(this.desc)
           },
           checkButton() {  
               var getSelectedValue = document.querySelector( 
                   'input[name="gt"]:checked'); 
               
               if(getSelectedValue != null) { 
                   document.getElementById("disp").innerHTML 
                       = getSelectedValue.value 
                       + " season is selected"; 
               } 
               else { 
                   document.getElementById("error").innerHTML 
                       = "*You have not selected any season"; 
               } 
           }  
       },
       created() {
           // this.save()
       }
   }
</script>