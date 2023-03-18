<template>
    <!-- <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"> -->

     <div id="form">
        <form class="form">
            <div class="form-top">
                <div class="form-title">
                    <h3 class="title">Thêm/sửa thông tin sinh viên</h3>
                    <span class="close" @click="closeForm">X</span>
                </div>
            </div>
            <div class="form-Wrap">
                <div class="column">
                    <div class="input__box">
                        <label for="">Mã sinh viên</label>
                        <input class="masv" type="text" v-model="desc.masv">
                        <div class="invalid-feedback" v-if="errors.masv">{{ errors.masv }}</div>
                    </div>
                    <div class="input__box">
                        <label for="">Tên sinh viên</label>
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
                        <div class="invalid-feedback" v-if="errors.gioitinh">{{ errors.gioitinh }}</div>
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
                        <combobox class="khoa " :value="desc.khoa" :items="dataItem" :code="'id'" :fieldName="'khoa'" @selectedItem="selectItemCbb"></combobox>
                        <!-- <combobox class="khoa " v-model="desc.khoa"></combobox> -->
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
                <div class="column">
                    <div class="input__box">
                        <label for="">Số tài khoản</label>
                        <input class="sotaikhoan" type="text" v-model="desc.sotaikhoan">
                        <div class="invalid-feedback" v-if="errors.sotaikhoan">{{ errors.sotaikhoan }}</div>
                    </div>
                    <div class="input__box">
                        <label for="">Địa chỉ</label>
                        <input class="sodt" type="text" v-model="desc.sodt">
                        <div class="invalid-feedback" v-if="errors.sodt">{{ errors.sodt }}</div>
                    </div>
                </div>
                <!-- <div class="input__box">    
                    <label for="">Địa chỉ</label>
                    <input class="diachi" type="text" v-model="desc.diachi">
                    <div class="invalid-feedback" v-if="errors.diachi">{{ errors.diachi }}</div>
                </div> -->
                <div class="column column-s">
                    <div class="input__box">
                        <label for="">Kỳ học</label>
                        <input class="kyhoc" type="text" v-model="desc.kyhoc">
                        <div class="invalid-feedback" v-if="errors.kyhoc">{{ errors.kyhoc }}</div>
                    </div>
                    <div class="input__box">
                        <label for="">Khen thưởng</label>
                        <input class="khenthuong" type="text" v-model="desc.khenthuong">
                        <div class="invalid-feedback" v-if="errors.khenthuong">{{ errors.khenthuong }}</div>
                    </div>

                </div>
                <div class="column column-s">
                    <div class="input__box">
                        <label for="">Chương trình đào tạo</label>
                        <input class="daotao" type="text" v-model="desc.daotao">
                        <div class="invalid-feedback" v-if="errors.daotao">{{ errors.daotao }}</div>
                    </div>
                    <div class="input__box">
                        <label for="">Ngày nhập học</label>
                        <input class="ngaynhaphoc" type="date" v-model="desc.ngaynhaphoc">
                        <div class="invalid-feedback" v-if="errors.ngaynhaphoc">{{ errors.ngaynhaphoc }}</div>
                    </div>
                    <div class="input__box">
                        <label for="">Ngày dự kiến tốt nghiệp</label>
                        <input class="ngaytotnghiep" type="date" v-model="desc.ngaytotnghiep">
                        <div class="invalid-feedback" v-if="errors.ngaytotnghiep">{{ errors.ngaytotnghiep }}</div>
                    </div>

                </div>
            </div>
            <div class="form-bottom">
                <div class="btn btn-cancel" @click="closeForm">Hủy</div>
                <div class="btn btn-save" @click="save()" >Lưu</div>
            </div>
        </form>

        <!-- Notification -->
        
   
    <notifi  v-show="isShowNotifi"  @closeNotifi="closeNo" @cancelNotifi="cancelForm"></notifi>
</div>
    
</template>

<script>
import notifi from "./FormNotifi.vue"
import combobox from "../base/BaseCombobox.vue"
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
                students: [],
                errors: {
                    masv: '',
                    ten: '',
                    gioitinh: '',
                    ngaysinh: '',
                    khoa: '',
                    cmnd: '',
                    ngaycap: '',
                    noicap: '',
                    email: '',
                    sodt: '',
                    sotaikhoan: '',
                    diachi: '',
                    kyhoc: '',
                    khenthuong: '',
                    daotao: '',
                    ngaynhaphoc: '',
                    ngaytotnghiep: '',
                },
                desc: {
                    id: '',
                    masv: '',
                    ten: '',
                    gioitinh: '',
                    ngaysinh: '',
                    khoa: '',
                    cmnd: '',
                    ngaycap: '',
                    noicap: '',
                    email: '',
                    sodt: '',
                    sotaikhoan: '',
                    diachi: '',
                    kyhoc: '',
                    khenthuong: '',
                    daotao: '',
                    ngaynhaphoc: '',
                    ngaytotnghiep: '',
                }
            }
        },
        props: ["student"],
        watch: {
            student: function(value){
                this.desc=value
                this.students=value
                this.desc.masv=value.msv
            }
        },
        components: {
            combobox,
            notifi
        },
        methods: {
           
            btnHidden(){
                this.isShow = !this.isShow
            },
            closeNo(value) {
                this.isShowNotifi = value;
                
            },
            cancelForm(value){
                this.isShowNotifi = value;
                 this.$emit("hideForm", false);
            },
            // gửi lệnh ẩn form từ bên này sang trang chính
            
            closeForm(){
                // this.$emit("hideForm", false);
                this.isShowNotifi = true,
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
                    masv: '',
                    ten: '',
                    gioitinh: '',
                    ngaysinh: '',
                    khoa: '',
                    cmnd: '',
                    ngaycap: '',
                    noicap: '',
                    email: '',
                    sodt: '',
                    sotaikhoan: '',
                    diachi: '',
                    kyhoc: '',
                    khenthuong: '',
                    daotao: '',
                    ngaynhaphoc: '',
                    ngaytotnghiep: '',
                }
                if(!this.desc.masv) {
                    this.errors.masv = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.ten) {
                    this.errors.ten = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.gioitinh) {
                    this.errors.gioitinh = "Không được để trống!";
                    isValid = false;
                }
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
                if(!this.desc.sotaikhoan) {
                    this.errors.sotaikhoan = "Không được để trống!";
                    isValid = false;
                }else if(!this.isNumber(this.desc.sotaikhoan)) {
                    this.errors.sotaikhoan = "Yêu cầu nhập số";
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
                if(!this.desc.ngaycap) {
                    this.errors.ngaycap = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.noicap) {
                    this.errors.noicap = "Không được để trống!";
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
                if(!this.desc.kyhoc) {
                    this.errors.kyhoc = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.khenthuong) {
                    this.errors.khenthuong = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.daotao) {
                    this.errors.daotao = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.ngaynhaphoc) {
                    this.errors.ngaynhaphoc = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.ngaytotnghiep) {
                    this.errors.ngaytotnghiep = "Không được để trống!";
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
                this.$emit("save",this.desc)
                console.log(this.desc)
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
<style>
label {
    margin: 10px 0;
}
.invalid-feedback {
    color: red;
    position: absolute;
    font-size: 12px;
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

 #form input {
    max-width: 100%;
    max-height: 26px;
    padding-bottom: 6px;
    border: 1px solid #ccc;
    border-radius: 2px;
    outline: none;
    position: relative;
    width: 100%;
    outline: none;
    padding-left: 5px;
    color: #000 !important;
    margin-top: 4px;
  }
  .form {
    width: fit-content;
    height: fit-content;
    background-color: #fff;
    margin: auto auto;
    border-radius: 8px;
    width:800px;
 
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
    .close:hover {
        opacity: 0.8;
    }
  .input__box {
    width: 100%;
    margin-bottom: 16px;
    margin-top: 10px;
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
  .btn:hover {
    opacity: 0.8;
  }
  .column {
    display: flex;
    column-gap: 20px;
  }
  .radio__box {
    display: flex;
    align-items: center;
    column-gap: 10px;
  }
  #form .radio__box input {
    width: 15px;
    margin: 0;
  }

  /* thongbao */
  
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