<template>
  <!-- Cảnh báo thêm lý lịch-->
    <!-- <div class="notification-wrap" v-if="isOpenPopupAddNotifiCV">
      <div class="notification">
          <div class="warring">
              <i class="icon-warning"></i>
              <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
          </div>
          <div class="btn-wrap">
              <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupAddNotifi = false, isOpenPopupAddState=false)" >Hủy</div>
              <div class="btnNotifi btn-primary" @click="isOpenPopupAddNotifi = false">Không</div>
          </div>
      </div>
    </div> -->
  <!--  -->
  <div id="form">
    <form class="form">
      <div class="form-top">
        <div class="form-title">
          <h2 class="title">{{ titleForm }}</h2>
          <span class="close" @click.stop="closeForm">X</span>
        </div>
      </div>
      <div class="form-Wrap">
        <div class="column">
          <div class="input__box">
            <label for="">Chức vụ <span>*</span></label>
            <combobox
              class="khoa"
              :value="salary.TenCVHT"
              :items="chucvuht"
              :code="'IDCVHT'"
              :fieldName="'TenCVHT'"
              @selectedItem="selectPositionNow"
            ></combobox>
            <div v-if="errors.CV!=''" class="invalid-feedback">
              {{ errors.CV }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Hệ số lương <span>*</span></label>
            <input @blur="validateName"  class="HSL" type="text" v-model="salary.HeSoLuong" />
            <div class="invalid-feedback" v-if="errors.HSL!=''">
              {{ errors.HSL }}
            </div>
          </div>
          
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Tên phụ cấp</label>
            <combobox
              class="khoa"
              :value="salary.TenPhuCap"
              :items="phucap"
              :code="'IDPhuCap'"
              :fieldName="'TenPhuCap'"
              @selectedItem="selectCbb"
            ></combobox>
            <div class="invalid-feedback" v-if="errors.pc!=''">
              {{ errors.pc }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Giá trị phụ cấp</label>
            <input class="sodt" type="text" v-model="salary.GiaTriPhuCap" />
            <div class="invalid-feedback" v-if="errors.GTPC">
              {{ errors.GTPC }}
            </div>
          </div>
        
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Ngạch lương</label>
            <combobox
              class="khoa"
              :value="salary.MaNgachLuong"
              :items="ngachluong"
              :code="'IDNgachLuong'"
              :fieldName="'MaNgachLuong'"
              @selectedItem="selectS"
            ></combobox>
          </div>
          <div class="input__box">
            <label for="">BHYT(%)</label>
            <input class="dantoc" type="text" v-model="salary.BHYT" />
            <div class="invalid-feedback" v-if="errors.dantoc">
              {{ errors.dantoc }}
            </div>
          </div>
        
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">BHXH(%)</label>
            <input @blur="validate" class="input-left" type="text" v-model="salary.BHXH" />
            <div class="invalid-feedback" v-if="errors.diachi">
              {{ errors.diachi }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Phần trăm hưởng lương(%)</label>
            <input class="dantoc" type="text" v-model="salary.PhanTramHuongLuong" />
            <div class="invalid-feedback" v-if="errors.dantoc">
              {{ errors.dantoc }}
            </div>
          </div>
        
        </div>

        <div class="column">
         
          <div class="input__box">
            <label for="">Tháng nhận</label>
            <input class="ngaycap input-left" v-model="salary.Thang" type="text" />
          </div>
          <div class="input__box">
            <label for="">Năm nhận</label>
            <input class="noicap" v-model="salary.Nam" type="text"  />
          </div>
        </div>

       
       
      </div>
      <div class="form-bottom">
        <div class="btn btn-cancel" @click="closeForm">Hủy</div>
        <div class="btn btn-save" @click="save">Lưu</div>
      </div>
    </form>
    <notifi
      v-show="isShowNotifi"
      @closeNotifi="closeNo"
      @cancelNotifi="FormCancel"
    ></notifi>
    <popUpDup @closeNotifi="closePoup" v-show="isShowPop"></popUpDup>
    
  </div>

  <!-- thongbao -->
</template>

<script>
 import notifi from "./FormNotifi.vue"
import combobox from "./BaseCombobox.vue";
import axios from "axios";
import { useToast } from "vue-toastification";

import popUpDup from "./PopUpDuplicateCode.vue"
export default {
  data() {
    return {
      isOpenPopupAddNotifiCV: false,
      employee: {},
      faculty: {},
      chucvuht: {},
      statusEmployee: {},
      certificate: {},
      position: {},
      salary: {},
      formMode: 0,
      ngachluong:{},
      titleForm:"",
      isShowNotifi: false,
      isShowPop:false,
      isShow: false,
      phucap:{},
      isValid:true,
      errors: {
        manv: "",
        ten: "",
        ngaysinh: "",
        cmnd: "",
        email: "",
        sodt: "",
        masothue: "",
        sotaikhoan: "",
        tennganhang: "",
        diachi: "",
        dantoc: "",
        tongiao: "",
        khoa: "",
        trangthai: "",
        capbacluong: "",
        phongban: "",
        chungchidaotao: "",
        tinhtrang: "",
        vitri: "",
      },
    };
  },
  props: ["employeeSL","code", "FormMode","loadData","title", "employeeId","IDNV","salarySL"],
  components: {
    combobox,popUpDup,
        notifi
  },
  watch: {
   
    code: function(vl){
        this.salary.EmployeeCode=vl
    },
    FormMode: function(value){
        this.formMode=value
    },
    
  },
  created() {
   
    this.formMode=this.FormMode
    this.titleForm=this.title
    if(this.formMode==1){
      this.salary=this.salarySL
    }
   if(this.formMode==0){
    this.salary.Nam=new Date().getFullYear()
    this.salary.Thang= new Date().getMonth()+1
   }
    
    this.salary.IDNhanVien=this.IDNV
    this.getPositionNow();
    // this.getFaculty();
    // this.getPosition();
    this.getAllowance();
    this.getSNL();
    // this.getCerti();
  },
  methods: {
    save(){
     
        // // this.getAllEmployee()
        // this.validateDateOfBirth()
        // this.validateEmail()
        // this.validateEmployeeCode()
        // this.validateIdentity()

        // this.validateName()
        // if(this.isValid==true){
          if(this.formMode==0){
          this.addSalary()
       
          }
      else{
        this.editSalary()
      }
    

    },
    closePoup(value){
this.isShowPop=value
    },
    getNewCode(){
      try {
       
       var me = this;
      
       axios
         .get(
          "https://localhost:44301/api/Employees/NewCode"
         )
         .then(function (res) {
          me.employee.EmployeeCode=res.data
         })
        
         .catch(function () {
           console.log(1);
         });
     } catch (error) {
       console.log(error);
     }
    },
    addSalary(){
        var me = this;
      console.log(me.salary);
       
      const toast = useToast();
      
        try {
        axios
          .post("https://localhost:44301/api/luong", me.salary)
          .then(function (res) {
            console.log("ok", res.data);
            me.salary={}
           
            toast.success("thêm dữ liệu thành công", { timeout: 2000 });
            me.$emit("hideFormAdd", false);
            me.$emit("loadData", false);
          })
         
          .catch(function () {
            toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
      
     
    },
    editSalary(){
      var me = this;
       
      const toast = useToast();
      try {
        axios
          .put(`https://localhost:44301/api/luong/${this.salary.IDLuong}`, me.salary)
          .then(function (res) {
            console.log("ok", res.data);
          
            toast.success("Sửa dữ liệu thành công", { timeout: 2000 });
            me.$emit("hideFormAdd", false);
            me.$emit("loadData", false);
          })
         
          .catch(function () {
            toast.error("Sửa dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }

    },
    selectItemCbb(value) {
      this.desc.khoa = value.khoa;
    },
    btnHidden() {
      this.isShow = !this.isShow;
    },
    closeNo(value) {
      this.isShowNotifi = value;
    },
    FormCancel(value) {
      this.isShowNotifi = value;
      this.$emit("hideFormAdd", false);
    },
    formatDate(date) {
      try {
        if (date) {
          date = new Date(date);
          let newDate = date.getDate();
          let month = date.getMonth() + 1;
          let year = date.getFullYear();
          newDate = newDate < 10 ? `0${newDate}` : newDate;
          month = month < 10 ? `0${month}` : month;
          return `${year}-${month}-${newDate}`;
        }
      } catch (error) {
        return "";
      }
    },
    //gửi lệnh ẩn form từ bên này sang trang chính
    closeForm() {
       this.isShowNotifi = true
      // this.$emit("hideForm", false);
      this.errors = {
        ten: "",
        ngaysinh: "",
        khoa: "",
        cmnd: "",
        ngaycap: "",
        noicap: "",
        email: "",
        sodt: "",
        masothue: "",
        sotaikhoan: "",
        tennganhang: "",
        trangthai: "",
        capbacluong: "",
        phongban: "",
        tinhtrang: "",
        diachi: "",
        daotao: "",
        khenthuong: "",
        kyluat: "",
      };
    },
    
    //gửi lệnh ẩn form từ bên này sang trang chính

    validateEmployeeCode() {
      
      if (!this.employee.EmployeeCode) {
        this.errors.manv = " Mã nhân viên không được để trống!";
        this.isValid = false;
      }else{
        this.errors.manv = "";
        this.isValid = true;
      }
      },
      validateName() {
      if (!this.employee.EmployeeName) {
        this.errors.ten = "Tên nhân viên Không được để trống!";
        this.isValid = false;
        // document.getElementsByClassName('ten').classList.add('borderRed')
      }
      
      else{
        this.errors.ten = "";
        this.isValid = true;
      }
    },
    validateIdentity() {
      if (!this.employee.IdentityNumber) {
        this.errors.cmnd = "CCCD Không được để trống!";
        this.isValid = false;
      }else{
        this.errors.cmnd = "";
        this.isValid = true;
      }
    },
    validateEmail() {
      if (!this.employee.Email) {
        this.errors.email = "Email Không được để trống!";
        this.isValid = false;
      }
      else if ((this.employee.Email)&&(!this.isEmail(this.employee.Email))){
        this.errors.email = "Email Không đúng định dạng!";
        this.isValid = false;
      }else{
        this.errors.email = "";
        this.isValid = true;
      }
    },
    isEmail(value) {
      var validRegex =
        /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
      return validRegex.test(value);
    },
    validateDateOfBirth(){
    if (this.employee.DateOfBirth) {
        this.employee.DateOfBirth = new Date(this.employee.DateOfBirth)
      }
      if (this.employee.DateOfBirth > new Date() && this.employee.DateOfBirth) {
        this.isValid = false;
        this.errors.ngaysinh="Ngày sinh không được lớn hơn ngày hiện tại!"
     
      } else {
        this.isValid = true;
      }
    },
    //  getAllEmployee(){
    //   try {
    //     var me = this;

    //     axios
    //       .get("https://localhost:44301/api/Employees")
    //       .then(function (res) {
          
    //         for (const item of res.data) {
            
    //          if(me.employee.EmployeeCode==item.EmployeeCode){
             
    //           me.isShowPop=!me.isShowPop
    //           me.isValid=false
    //          }else{
    //           me.isValid=true
    //          }
    //         }
    //       })

    //       .catch(function () {
    //         console.log(1);
    //       });
    //   } catch (error) {
    //     console.log(error);
    //   }
    //  },
    checkButton() {
      var getSelectedValue = document.querySelector('input[name="gt"]:checked');

      if (getSelectedValue != null) {
        document.getElementById("disp").innerHTML =
          getSelectedValue.value + " season is selected";
      } else {
        document.getElementById("error").innerHTML =
          "*You have not selected any season";
      }
    },

    /**
     * lấy dữ liệu để đổ vào combobox
     */
    getPositionNow() {
      try {
        var me = this;

        axios
          .get("https://localhost:44301/api/ChucVuHT")
          .then(function (res) {
            me.chucvuht = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },

    getPosition() {
      try {
        var me = this;

        axios
          .get("https://localhost:44301/api/Position")
          .then(function (res) {
            me.position = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },

    getAllowance() {
      try {
        var me = this;

        axios
          .get("https://localhost:44301/api/phucap")
          .then(function (res) {
            me.phucap = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
  
    getSNL() {
      try {
        var me = this;

        axios
          .get("https://localhost:44301/api/ngachluong")
          .then(function (res) {
            me.ngachluong = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    
    selectCbb(value){
      this.salary.TenPhuCap=value.TenPhuCap
      this.salary.GiaTriPhuCap= value.GiaTriPhuCap
      this.salary.IDPhuCap=value.IDPhuCap
    },
    selectPositionNow(value) {
      this.salary.IDCVHT = value.IDCVHT;
      this.salary.TenCVHT = value.TenCVHT;
      this.salary.BHXH=value.BHXH
      this.salary.BHYT=value.BHYT
      this.salary.HeSoLuong=value.HeSoLuong
      this.salary.PhanTramHuongLuong=100 - parseFloat(value.BHXH)  - parseFloat(value.BHYT) 
    },
    selectS(value){
      this.salary.IDNgachLuong=value.IDNgachLuong
      this.salary.TenNgachLuong=value.TenNgachLuong
      this.salary.MaNgachLuong=value.MaNgachLuong
    }
  },
};
</script>
<style >

.icon-down-bold {
    background: url(http://localhost:8080/img/qlts-icon.c1b7328e.svg) no-repeat -72px -338px;
    width: 8px;
    height: 10px;
}
.m-combobox .icon {
    position: absolute;
    left: -19px;
    top: 7px;
    /* transform: translateX(-50%); */
    cursor: pointer;
}

input-left{
  width: 340px !important;
}
label {
  margin: 10px 0;
}
label span{
  color: red;
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
  color: #707070;
  margin-top: 7px;
}
.form {
  width: fit-content;
  height: fit-content;
  background-color: #fff;
  margin: auto auto;
  border-radius: 18px;
  width: 800px;
  padding: 16px;
  box-shadow: 5px rgba(0, 0, 0, 0.2);
  /* display: none; */
}
.form-Wrap {
  padding: 0 20px;
}
.form-title {
  padding: 0 13px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 0px;
  border-top-right-radius: 20px;
  border-top-left-radius: 20px;
  background-color: #fff !important;
}
.close {
  cursor: pointer;
  font-weight: 600;
  font-size: 18px;
  color: #726c6c;
}
.close:hover {
  color: red;
}
.input__box {
  display: block;
  width: 100%;
  margin-bottom: 10px;
}
.form-bottom {
  border-bottom-left-radius: 20px;
  border-bottom-right-radius: 20px;
  display: flex;
  justify-content: flex-end;
  padding: 8px;
  background-color: #fff !important;
  gap: 28px;
  margin-top: 2px;
}
.btn-cancel {
  border: 1px solid #ccc;
}
.btn-cancel:hover {
  background-color: red;
  color: #fff;
}
.btn-save {
  border: 1px solid #1a8fdd;
  background-color: #1a8fdd;
  color: #fff;
}
.btn-save:hover {
  background-color: #fff;
  color: #000;
  border: 1px solid #1a8fdd;
}
.btn {
  padding: 10px 20px;
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
  width: 50%;
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
 /* .khoa {
    margin-top: 4px;
  } */
  .important {
    color: red;
  }
  .borderRed{
  border: 1px solid red !important;
}
.notification-wrap {
    background-color: rgba(0, 0, 0, 0.2);
    z-index: 4;
    width: 100%;
    height: 100%;
    margin: auto;
    position: fixed;
    display: flex;
  
    }
    .notification{
        z-index: 3;
        position: absolute;
        left: 50%;
        top: 50%;
        transform: translate(-50%,-50%);
        background-color: #fff;
        width: 420px;
        height: 150px;
        padding: 20px;
        border-radius: 2px;
        box-shadow: rgba(50, 50, 93, 0.25) 0px 13px 27px -5px, rgba(0, 0, 0, 0.3) 0px 8px 16px -8px;
    }
    .warring{
        display: flex;
        justify-content: center;
        align-items: center;
        margin-top: 30px;
    }
    .warring i {
        font-size: 60px;
        width: 52px;
        height: 40px;
        color: #F4A733;
    }
    .warrning-title{
        text-align: center;
        font-size: 16px;
        margin-left: 8px;
    }
    .btn-wrap {
        display: flex;
        justify-content: flex-end;
        align-items: center;
        column-gap: 20px;
    }
    .btnNotifi{   
        display: flex;
        width: 100px;
        align-items: center;
        justify-content: center;
        margin-top: 38px;
        border-radius: 2px;
        height: 25px;
        cursor: pointer;
    }
    .btnNotifi:hover {
        opacity: 0.8;
        color: red;
    }
    .btn-secondary{
        border: 1px solid #1A8FDD;
    }
    .btn-primary{
        margin-right: 40px;
        background-color: #1A8FDD;
        color: #fff;
    }
   
    @media screen and (max-width: 767.98px) {
        .notification{
            font-size: 15px;
            width: 300px;
            height: 130px;
            padding: 14px;
        }
        .warring {
            margin-top: 6px;
        }
        .warring i {
            font-size: 50px;
        }
        .btnNotifi {
            width: 80px;
            margin-top: 20px;
        }
    }
</style>
