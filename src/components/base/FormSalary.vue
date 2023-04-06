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
            <combobox style="margin-top: 10px" class="khoa errorInput" :value="salary.TenCVHT" :items="chucvuht"
              :code="'IDCVHT'" :fieldName="'TenCVHT'" @selectedItem="selectPositionNow"
              :border="errors.chucvu != '' ? 'borderRed' : ''" @onBlur="validateCV">
            </combobox>
            <div v-if="errors.chucvu != ''" class="invalid-feedback">
              {{ errors.chucvu }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Hệ số lương </label>
            <input @blur="validateName" class="HSL" type="text" v-model="salary.HeSoLuong" />
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Tên phụ cấp</label>
            <combobox style="margin-top: 10px" class="khoa" :value="salary.TenPhuCap" :items="phucap" :code="'IDPhuCap'"
              :fieldName="'TenPhuCap'" @selectedItem="selectCbb"></combobox>
          </div>
          <div class="input__box">
            <label for="">Giá trị phụ cấp</label>
            <input class="sodt" type="text" v-model="salary.GiaTriPhuCap" />
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Ngạch lương<span>*</span></label>
            <combobox style="margin-top: 10px" class="khoa errorInput" :value="salary.MaNgachLuong" :items="ngachluong"
              :code="'IDNgachLuong'" :fieldName="'MaNgachLuong'" @selectedItem="selectS"
              :border="errors.ngachLuong != '' ? 'borderRed' : ''" @onBlur="validateNgachLuong"></combobox>
            <div class="invalid-feedback" v-if="errors.ngachLuong">
              {{ errors.ngachLuong }}
            </div>
          </div>
          <div class="input__box">
            <label for="">BHYT(%)</label>
            <input class="dantoc" type="text" v-model="salary.BHYT" />
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">BHXH(%)</label>
            <input @blur="validate" class="input-left" type="text" v-model="salary.BHXH" />
          </div>
          <div class="input__box">
            <label for="">Phần trăm hưởng lương(%)</label>
            <input class="dantoc" type="text" v-model="salary.PhanTramHuongLuong" />
          </div>
        </div>

        <div class="column">
          <div class="input__box">
            <label for="">Tháng nhận<span>*</span></label>
            <input class="ngaycap input-left" v-model="salary.Thang" type="text"
              :class="errors.thang != '' ? 'borderRed' : ''" @blur="validateThang" />
            <div class="invalid-feedback" v-if="errors.thang">
              {{ errors.thang }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Năm nhận<span>*</span></label>
            <input
              class="noicap"
              v-model="salary.Nam"
              type="text"
              :class="errors.nam != '' ? 'borderRed' : ''"
              @blur="validateNam"
            />
            <div class="invalid-feedback" v-if="errors.nam">
              {{ errors.nam }}
            </div>
          </div>
        </div>
      </div>
      <div class="form-bottom">
        <div class="btn btn-cancel" @click="closeForm">Hủy</div>
        <div class="btn btn-save" @click="save">Lưu</div>
      </div>
    </form>
    <notifi v-show="isShowNotifi" @closeNotifi="closeNo" @cancelNotifi="FormCancel"></notifi>
    <popUpDup @closeNotifi="closePoup" v-show="isShowPop"></popUpDup>
  </div>
  <Warning v-show="isShowWarning" @closePopUpWarning="isShowWarning = false" :msg="msgWarning"></Warning>
  <!-- thongbao -->
</template>

<script>
import notifi from "./FormNotifi.vue";
import combobox from "./BaseCombobox.vue";
import axios from "axios";
import { useToast } from "vue-toastification";
import Warning from './BasePopupWarningDelete.vue'
import popUpDup from "./PopUpDuplicateCode.vue";
export default {
  data() {
    return {

      isOpenPopupAddNotifiCV: false,
      employee: {},
      faculty: {},
      msgWarning: "",
      isShowWarning: false,
      chucvuht: {},
      statusEmployee: {},
      certificate: {},
      position: {},
      salary: {},
      formMode: 0,
      ngachluong: {},
      titleForm: "",
      isShowNotifi: false,
      isShowPop: false,
      isShow: false,
      phucap: {},
      isValid: false,
      listData: {},
      listYear: [],
      isValidYear: false,
      errors: {
        chucvu: "",
        ngachLuong: "",
        thang: "",
        nam: "",
      },
    };
  },
  props: [
    "employeeSL",
    "code",
    "FormMode",
    "loadData",
    "title",
    "employeeId",
    "IDNV",
    "salarySL",
  ],
  components: {
    combobox,
    popUpDup,
    notifi, Warning
  },
  watch: {
    code: function (vl) {
      this.salary.EmployeeCode = vl;
    },
    FormMode: function (value) {
      this.formMode = value;
    },
  },
  created() {
    this.getSalaryByID()
    this.formMode = this.FormMode;
    this.titleForm = this.title;
    if (this.formMode == 1) {
      this.salary = this.salarySL;
    }
    if (this.formMode == 0) {
      this.salary.Nam = new Date().getFullYear();
      this.salary.Thang = new Date().getMonth() + 1;
    }

    this.salary.IDNhanVien = this.IDNV;
    this.getPositionNow();
    // this.getFaculty();
    // this.getPosition();
    this.getAllowance();
    this.getSNL();
   
    // this.getCerti();
  },
  methods: {
    getSalaryByID() {
      try {
        var me = this;

        axios
          .get(`https://localhost:44301/api/luong/${this.salary.IDNhanVien}`)
          .then(function (res) {
            console.log(res.data);
            me.listData = res.data
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    validateYear() {
      for (const item of this.listData) {
        if (this.salary.Nam == item.Nam && this.salary.Thang == item.Thang) {
          this.msgWarning = "Thông tin lương " + this.salary.Thang + "/" + this.salary.Nam + " của nhân viên này đã tồn tại"
          this.isShowWarning = true
          this.isValidYear = false
        } else {
          this.msgWarning = ""
          this.isValidYear = true
          this.isShowWarning = false
        }
      }
    },
    save() {
      const toast = useToast();
      // this.getAllEmployee()
      this.validateCV();
      this.validateNgachLuong();
      this.validateThang();
      this.validateNam();
      
      console.log(this.isValid);
      if (this.isValid == true) {
        if (this.formMode == 0) {
         
          this.validateYear()
          if (this.isValidYear == true) {
            this.addSalary();
          } else {
            this.msgWarning = "Thông tin lương " + this.salary.Thang + "/" + this.salary.Nam + " của nhân viên này đã tồn tại"
            this.isShowWarning = true
          }

        } else {
          this.editSalary();
        }
      } else {
        toast.error("cần nhập đúng dữ liệu", { timeout: 5000 });
      }
    },
    closePoup(value) {
      this.isShowPop = value;
    },

    getNewCode() {
      try {
        var me = this;

        axios
          .get("https://localhost:44301/api/Employees/NewCode")
          .then(function (res) {
            me.employee.EmployeeCode = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    addSalary() {
      var me = this;

      console.log(me.salary);

      const toast = useToast();

      try {
        axios
          .post("https://localhost:44301/api/luong", me.salary)
          .then(function (res) {
            console.log("ok", res.data);
            me.salary = {};

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
    editSalary() {
      var me = this;

      const toast = useToast();
      try {
        axios
          .put(
            `https://localhost:44301/api/luong/${this.salary.IDLuong}`,
            me.salary
          )
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
      this.isShowNotifi = true;
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

    validateCV() {
      if (!this.salary.TenCVHT) {
        this.errors.chucvu = " Chức vụ không được để trống!";
        this.isValid = false;
      } else {
        this.errors.chucvu = "";
        this.isValid = true;
      }
    },
    validateNgachLuong() {
      if (!this.salary.MaNgachLuong) {
        this.errors.ngachLuong = "Ngạch lương Không được để trống!";
        this.isValid = false;
        // document.getElementsByClassName('ten').classList.add('borderRed')
      } else {
        this.errors.ngachLuong = "";
        this.isValid = true;
      }
    },
    validateThang() {
      if (!this.salary.Thang) {
        this.errors.thang = "Tháng nhận Không được để trống!";
        this.isValid = false;
      } else {
        this.errors.thang = "";
        this.isValid = true;
      }
    },
    validateNam() {
      if (!this.salary.Nam) {
        this.errors.nam = "Năm nhận Không được để trống!";
        this.isValid = false;
      } else {
        this.errors.nam = "";
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

    selectCbb(value) {
      this.salary.TenPhuCap = value.TenPhuCap;
      this.salary.GiaTriPhuCap = value.GiaTriPhuCap;
      this.salary.IDPhuCap = value.IDPhuCap;
    },
    selectPositionNow(value) {
      this.salary.IDCVHT = value.IDCVHT;
      this.salary.TenCVHT = value.TenCVHT;
      this.salary.BHXH = value.BHXH;
      this.salary.BHYT = value.BHYT;
      this.salary.HeSoLuong = value.HeSoLuong;
      this.salary.PhanTramHuongLuong =
        100 - parseFloat(value.BHXH) - parseFloat(value.BHYT);
    },
    selectS(value) {
      this.salary.IDNgachLuong = value.IDNgachLuong;
      this.salary.TenNgachLuong = value.TenNgachLuong;
      this.salary.MaNgachLuong = value.MaNgachLuong;
    },
  },
};
</script>
<style scoped>
.bonus-form {
  padding: 0px 20px;
  position: absolute;
  width: 80vw;
  height: 590px;
  top: 12%;
  right: 14%;
  z-index: 99999;
  border-radius: 20px;
  box-shadow: 5px 5px 5px;
  background-color: #fff;
}

.icon-down-bold {
  background: url(http://localhost:8080/img/qlts-icon.c1b7328e.svg) no-repeat -72px -338px;
  width: 8px;
  height: 10px;
}



input-left {
  width: 340px !important;
}

label {
  margin: 10px 0;
}

label span {
  color: red;
}

.invalid-feedback {
  color: red;
  position: absolute;
  font-size: 11px;
  margin-top: 6px;
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

#form .errorInput input {
  margin-top: 23px !important;
}

#form input {
  max-width: 100%;

  padding-bottom: 6px;

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
  margin-top: 5%;
  margin-left: 22%;
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
  margin-bottom: 30px;
  position: relative;
}

.m-combobox .icon {
  position: absolute;
  left: -19px;
  top: 4px !important;
  /* transform: translateX(-50%); */
  cursor: pointer;
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
  border: 1px solid #1a8fdd;
  color: #1a8fdd;
  background: #fff;
}

.btn-cancel:hover {
  background-color: #1a8fdd;
  color: #fff;
}

.btn-save {
  border: 1px solid #1a8fdd;
  background-color: #1a8fdd;
  color: #fff;
}

.btn-save:hover {
  background-color: #fff;
  color: #1a8fdd;
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

.borderRed {
  border-color: red !important;
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

.notification {
  z-index: 3;
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
  background-color: #fff;
  width: 420px;
  height: 150px;
  padding: 20px;
  border-radius: 2px;
  box-shadow: rgba(50, 50, 93, 0.25) 0px 13px 27px -5px,
    rgba(0, 0, 0, 0.3) 0px 8px 16px -8px;
}

.warring {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 30px;
}

.warring i {
  font-size: 60px;
  width: 52px;
  height: 40px;
  color: #f4a733;
}

.warrning-title {
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

.btnNotifi {
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

.btn-secondary {
  border: 1px solid #1a8fdd;
}

.btn-primary {
  margin-right: 40px;
  background-color: #1a8fdd;
  color: #fff;
}

@media screen and (max-width: 767.98px) {
  .notification {
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
