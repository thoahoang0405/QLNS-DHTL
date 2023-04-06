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
            <label for="">Mã nhân viên <span>*</span></label>
            <input disabled @blur="validateEmployeeCode" class="manv" :class="errors.manv != '' ? 'borderRed' : ''"
              type="text" v-model="employee.MaNV" />
            <div v-if="errors.manv != ''" class="invalid-feedback">
              {{ errors.manv }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Tên nhân viên <span>*</span></label>
            <input @blur="validateName" :class="errors.ten != '' ? 'borderRed' : ''" class="ten" type="text"
              v-model="employee.TenNV" />
            <div class="invalid-feedback" v-if="errors.ten != ''">
              {{ errors.ten }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Giới tính</label>
            <div class="radio__box">
              <input type="radio" id="nam" v-model="employee.GioiTinh" value="0" />
              <label class="nam" for="">Nam</label>
              <input type="radio" id="nu" v-model="employee.GioiTinh" value="1" />
              <label class="nu" for="">Nữ</label>
            </div>
            <div class="invalid-feedback" v-if="errors.gioitinh">
              {{ errors.gioitinh }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Ngày sinh </label>
            <input :class="errors.ngaysinh != '' ? 'borderRed' : ''" class="ngaysinh" type="date"
              v-model="employee.NgaySinh" />
            <div class="invalid-feedback" v-if="errors.ngaysinh != ''">
              {{ errors.ngaysinh }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Số điện thoại</label>
            <input class="sodt" type="text" v-model="employee.SDT" />
            <div class="invalid-feedback" v-if="errors.sodt">
              {{ errors.sodt }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Email <span>*</span></label>
            <input @blur="validateEmail" :class="errors.email != '' ? 'borderRed' : ''" class="email" type="text"
              v-model="employee.Email" />
            <div class="invalid-feedback" v-if="errors.email">
              {{ errors.email }}
            </div>
          </div>
        </div>

        <div class="column">
          <div class="input__box">
            <label for="">Địa chỉ</label>
            <input @blur="validate" class="diachi" type="text" v-model="employee.DiaChi" />
            <div class="invalid-feedback" v-if="errors.diachi">
              {{ errors.diachi }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Dân tộc</label>
            <input class="dantoc" type="text" v-model="employee.DanToc" />
            <div class="invalid-feedback" v-if="errors.dantoc">
              {{ errors.dantoc }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Tôn giáo</label>
            <input class="tongiao" type="text" v-model="employee.TonGiao" />
            <div class="invalid-feedback" v-if="errors.tongiao">
              {{ errors.tongiao }}
            </div>
          </div>
        </div>

        <div class="column">
          <div class="input__box">
            <label for="">Cmnd/cccd <span>*</span></label>
            <input @blur="validateIdentity" class="cmnd" type="text" :class="errors.cmnd != '' ? 'borderRed' : ''"
              v-model="employee.CCCD" />
            <div class="invalid-feedback" v-if="errors.cmnd != ''">
              {{ errors.cmnd }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Ngày cấp</label>
            <input class="ngaycap" v-model="employee.NgayCap" type="date" />
          </div>
          <div class="input__box">
            <label for="">Nơi cấp</label>
            <input class="noicap" v-model="employee.NoiCap" type="text" />
          </div>
        </div>

        <div class="column column-s">
          <div class="input__box">
            <label for="">Mã khoa <span>*</span></label>
            <combobox style="margin-top: 10px" class="khoa errorInput" :value="employee.MaKhoa" :items="faculty"
              :code="'IDKhoa'" :fieldName="'TenKhoa'" @selectedItem="selectItemFaculty"></combobox>

          </div>
          <div class="input__box">
            <label for="">Tên Khoa</label>
            <input disabled class="makhoa" type="text" v-model="employee.TenKhoa" />
            <!-- <div class="invalid-feedback" v-if="errors.khoa">
              {{ errors.khoa }}
            </div> -->
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

  <!-- thongbao -->
</template>

<script>
import notifi from "./FormNotifi.vue"
import combobox from "../base/BaseCombobox.vue";
import axios from "axios";
import { useToast } from "vue-toastification";

import popUpDup from "../base/PopUpDuplicateCode.vue"
export default {
  data() {
    return {
      isOpenPopupAddNotifiCV: false,
      employee: {},
      faculty: {},
      department: {},
      statusEmployee: {},
      certificate: {},
      position: {},
      salary: {},
      formMode: 1,
      isShowNotifi: false,
      isShowPop: false,
      isShow: false,
      isValid: true,
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
  props: ["employeeSL", "code", "FormMode", "loadData", "employeeId", "titleForm"],
  components: {
    combobox, popUpDup,
    notifi
  },
  watch: {
    employeeSL: function (value) {
      this.employee = value
      value.NgaySinh = this.formatDate(value.NgaySinh)
      this.employee.NgaySinh = value.NgaySinh
      value.NgayCap = this.formatDate(value.NgayCap)
      this.employee.NgayCap = value.NgayCap
      this.employee.IDNhanVien = value.IDNhanVien
    },
    code: function (vl) {
      this.employee.MaNV = vl
    },
    FormMode: function (value) {
      this.formMode = value
    },

  },
  created() {
    // this.getDepartment();
    this.getFaculty();
    // this.getPosition();
    // this.getSalary();
    // this.getstatus();
    // this.getCerti();
  },
  methods: {
    save() {

      // this.getAllEmployee()
      this.validateDateOfBirth()
      this.validateEmail()
      this.validateEmployeeCode()
      this.validateIdentity()

      this.validateName()
      if (this.isValid == true) {
        if (this.formMode == 1) {
          this.addEmployee()
        }

        else {
          this.editEmployee()
        }
      }

    },
    closePoup(value) {
      this.isShowPop = value
    },
    getNewCode() {
      try {

        var me = this;

        axios
          .get(
            "https://localhost:44301/api/nhanvien/NewCode"
          )
          .then(function (res) {
            me.employee.MaNV = res.data
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    addEmployee() {
      var me = this;

      console.log(me.employee);
      me.employee.Gender = parseInt(me.employee.Gender)
      const toast = useToast();

      try {
        axios
          .post("https://localhost:44301/api/nhanvien", me.employee)
          .then(function (res) {
            console.log("ok", res.data);
            me.employee = {}
            me.$emit("hideForm", false);
            me.getNewCode()
            toast.success("thêm dữ liệu thành công", { timeout: 2000 });
            me.loadData()
          })

          .catch(function () {
            toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }


    },
    editEmployee() {
      var me = this;
      console.log(me.employee);
      me.employee.GioiTinh = parseInt(me.employee.GioiTinh)
      const toast = useToast();
      try {
        axios
          .put(`https://localhost:44301/api/nhanvien/${this.employee.IDNhanVien}`, me.employee)
          .then(function (res) {
            console.log("ok", res.data);
            me.$emit("hideForm", false);
            toast.success("Sửa dữ liệu thành công", { timeout: 2000 });
            me.loadData()
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
      this.$emit("hideForm", false);
      this.errors = {
        manv:"",
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
      this.errors.manv = ""
      this.errors = {
        manv:"",
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

      if (!this.employee.MaNV) {
        this.errors.manv = " Mã nhân viên không được để trống!";
        this.isValid = false;
      } else {
        this.errors.manv = "";
        this.isValid = true;
      }
    },
    validateName() {
      if (!this.employee.TenNV) {
        this.errors.ten = "Tên nhân viên Không được để trống!";
        this.isValid = false;
        // document.getElementsByClassName('ten').classList.add('borderRed')
      }
      else {
        this.errors.ten = "";
        this.isValid = true;
      }
    },
    validateIdentity() {
      if (!this.employee.CCCD) {
        this.errors.cmnd = "CCCD Không được để trống!";
        this.isValid = false;
      } else {
        this.errors.cmnd = "";
        this.isValid = true;
      }
    },
    validateEmail() {
      if (!this.employee.Email) {
        this.errors.email = "Email Không được để trống!";
        this.isValid = false;
      }
      else if ((this.employee.Email) && (!this.isEmail(this.employee.Email))) {
        this.errors.email = "Email Không đúng định dạng!";
        this.isValid = false;
      } else {
        this.errors.email = "";
        this.isValid = true;
      }
    },
    isEmail(value) {
      var validRegex =
        /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
      return validRegex.test(value);
    },
    validateDateOfBirth() {
      if (this.employee.NgaySinh) {
        this.employee.NgaySinh = new Date(this.employee.NgaySinh)
      }
      if (this.employee.NgaySinh > new Date() && this.employee.NgaySinh) {
        this.isValid = false;
        this.errors.ngaysinh = "Ngày sinh không được lớn hơn ngày hiện tại!"

      } else {
        this.isValid = true;
      }
    },

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
    getDepartment() {
      try {
        var me = this;

        axios
          .get("https://localhost:44301/api/Departments")
          .then(function (res) {
            me.department = res.data;
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

    getSalary() {
      try {
        var me = this;

        axios
          .get("https://localhost:44301/api/Salary")
          .then(function (res) {
            me.salary = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    getCerti() {
      try {
        var me = this;

        axios
          .get("https://localhost:44301/api/TranningCertification")
          .then(function (res) {
            me.certificate = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    getstatus() {
      try {
        var me = this;

        axios
          .get("https://localhost:44301/api/StatusEmployee")
          .then(function (res) {
            me.statusEmployee = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    getFaculty() {
      try {
        var me = this;

        axios
          .get("https://localhost:44301/api/khoa")
          .then(function (res) {
            me.faculty = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    selectItemDepartment(value) {
      this.employee.DepartmentID = value.DepartmentID;
      this.employee.DepartmentName = value.DepartmentName;
    },
    selectItemPosition(value) {
      this.employee.PositionsID = value.PositionsID;
      this.employee.PositionsName = value.PositionsName;
    },
    selectItemCertifi(value) {
      this.employee.TrainingCertificateID = value.TrainingCertificationID;
      this.employee.TrainingCertificateName = value.TrainingCertificationName;
    },
    selectItemSalary(value) {
      this.employee.SalaryID = value.SalaryID;
      this.employee.SalaryName = value.SalaryName;
    },
    selectItemStatus(value) {
      this.employee.StatusEmployeeID = value.StatusEmployeeID;
      this.employee.StatusEmployeeName = value.StatusEmployeeName;
    },
    selectItemFaculty(value) {
      this.employee.IDKhoa = value.IDKhoa;
      this.employee.TenKhoa = value.TenKhoa;
      this.employee.MaKhoa = value.MaKhoa
    },
    OpenPopupAddNotifiCV(item) {
      this.isOpenPopupAddNotifiCV = true;
      this.dataSinhVienPunish = item
    },
  },
};
</script>
<style scoped>
#form .errorInput input {
  margin-top: 23px !important;
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

  padding-bottom: 6px;

  border-radius: 2px;
  outline: none;
  position: relative;
  width: 100%;
  outline: none;
  padding-left: 5px;
  color: #000;
  margin-top: 7px;
}

.form {
  width: fit-content;
  height: fit-content;
  background-color: #fff;
  margin-top: 7%;
  margin-left: 22%;
  border-radius: 18px;
  width: 800px;
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
  border: 1px solid #1A8FDD;
  color: red;
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

.borderRed {
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
  box-shadow: rgba(50, 50, 93, 0.25) 0px 13px 27px -5px, rgba(0, 0, 0, 0.3) 0px 8px 16px -8px;
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
  color: #F4A733;
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
  height: 34px;
  cursor: pointer;
}

.btnNotifi:hover {
  opacity: 0.8;
  color: red;
}

.btn-secondary {
  border: 1px solid #1A8FDD;
}

.btn-primary {
  margin-right: 40px;
  background-color: #1A8FDD;
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
