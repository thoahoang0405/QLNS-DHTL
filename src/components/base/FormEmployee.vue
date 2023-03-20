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
            <label for="">Mã nhân viên <span>*</span></label>
            <input @blur="validate" class="manv" type="text" v-model="employee.EmployeeCode" />
            <div class="invalid-feedback" v-if="errors.manv">
              {{ errors.manv }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Tên nhân viên <span>*</span></label>
            <input @blur="validate" class="ten" type="text" v-model="employee.EmployeeName" />
            <div class="invalid-feedback" v-if="errors.ten">
              {{ errors.ten }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Giới tính</label>
            <div class="radio__box">
              <input
                type="radio"
                id="nam"
                v-model="employee.Gender"
                value="0"
              />
              <label class="nam" for="">Nam</label>
              <input
                type="radio"
                id="nu"
                v-model="employee.Gender"
                value="1"
              />
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
            <input
              class="ngaysinh"
              type="date"
              v-model="employee.DateOfBirth"
            />
            <div class="invalid-feedback" v-if="errors.ngaysinh">
              {{ errors.ngaysinh }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Cmnd/cccd <span>*</span></label>
            <input @blur="validate" class="cmnd" type="text" v-model="employee.IdentityNumber" />
            <div class="invalid-feedback" v-if="errors.cmnd">
              {{ errors.cmnd }}
            </div>
          </div>

          <div class="input__box">
            <label for="">Email <span>*</span></label>
            <input @blur="validate"  class="email" type="text" v-model="employee.Email" />
            <div class="invalid-feedback" v-if="errors.email">
              {{ errors.email }}
            </div>
          </div>
        </div>

        <div class="column">
          <div class="input__box">
            <label for="">Số điện thoại<span class="important">*</span></label>
            <input class="sodt" type="text" v-model="employee.Phonenumber" />
            <div class="invalid-feedback" v-if="errors.sodt">
              {{ errors.sodt }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Mã số thuế</label>
            <input class="masothue" type="text" v-model="employee.TaxCode" />
            <!-- <div class="invalid-feedback" v-if="errors.masothue">
              {{ errors.masothue }}
            </div> -->
          </div>
          <div class="input__box">
            <label for="">Số tài khoản</label>
            <input class="sotaikhoan" type="text" v-model="employee.BankAccountNumber" />
            <!-- <div class="invalid-feedback" v-if="errors.sotaikhoan">
              {{ errors.sotaikhoan }}
            </div> -->
          </div>
        </div>
        <div class="column column-s">
          <div class="input__box">
            <label for="">Tên ngân hàng</label>
            <input class="tennganhang" type="text" v-model="employee.BankAccountName" />
            <!-- <div class="invalid-feedback" v-if="errors.tennganhang">
              {{ errors.tennganhang }}
            </div> -->
          </div>
          <div class="input__box">
            <label for="">Địa chỉ<span class="important">*</span></label>
            <input @blur="validate" class="diachi" type="text" v-model="employee.Adress" />
            <div class="invalid-feedback" v-if="errors.diachi">
              {{ errors.diachi }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Tình trạng hôn nhân</label>
            <input class="tinhtrang" type="text" v-model="employee.MaritalStatus" />
            <div class="invalid-feedback" v-if="errors.tinhtrang">
              {{ errors.tinhtrang }}
            </div>
          </div>
        </div>
        <div class="column column-s">
          <div class="input__box">
            <label for="">Trạng thái</label>
            <combobox
              class="trangthai"
              :value="employee.StatusEmployeeName"
              :items="statusEmployee"
              :code="'StatusEmployeeID'"
              :fieldName="'StatusEmployeeName'"
              @selectedItem="selectItemStatus"
            ></combobox>
            <div class="invalid-feedback" v-if="errors.trangthai">
              {{ errors.trangthai }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Cấp bậc lương</label>
            <combobox
              class="capbacluong"
              :value="employee.SalaryName"
              :items="salary"
              :code="'SalaryID'"
              :fieldName="'SalaryName'"
              @selectedItem="selectItemSalary"
            ></combobox>
            <div class="invalid-feedback" v-if="errors.capbacluong">
              {{ errors.capbacluong }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Phòng ban</label>
            <combobox
              class="phongban"
              :value="employee.DepartmentName"
              :items="department"
              :code="'DeparmentID'"
              :fieldName="'DepartmentName'"
              @selectedItem="selectItemDepartment"
            ></combobox>
            <div class="invalid-feedback" v-if="errors.phongban">
              {{ errors.phongban }}
            </div>
          </div>
        </div>

        <div class="column column-s">
          <div class="input__box">
            <label for="">Chứng chỉ đào tạo</label>
            <combobox
              class="daotao"
              :value="employee.TrainingCertificateName"
              :items="certificate"
              :code="'TrainingCertificationID'"
              :fieldName="'TrainingCertificationName'"
              @selectedItem="selectItemCertifi"
            ></combobox>
            <div class="invalid-feedback" v-if="errors.chungchidaotao">
              {{ errors.chungchidaotao }}
            </div>
            <!-- <input class="daotao" type="text" v-model="desc.daotao"> -->
          </div>
          <div class="input__box">
            <label for="">Khoa</label>
            <combobox
              class="khoa"
              :value="employee.FacultyName"
              :items="faculty"
              :code="'FacultyID'"
              :fieldName="'FacultyName'"
              @selectedItem="selectItemFaculty"
            ></combobox>
            <div class="invalid-feedback" v-if="errors.khoa">
              {{ errors.khoa }}
            </div>
            <!-- <input class="khoa" type="text" v-model="desc.khoa"> -->
          </div>
          <div class="input__box">
            <label for="">Vị trí</label>
            <combobox
              class="vtri"
              :value="employee.PositionsName"
              :items="position"
              :code="'PositionsID'"
              :fieldName="'PositionsName'"
              @selectedItem="selectItemPosition"
            ></combobox>
            <div class="invalid-feedback" v-if="errors.vitri">
              {{ errors.vitri }}
            </div>
          </div>
        </div>
        
        <div class="column">
          <div class="input__box">
            <label for="">Dân tộc</label>
            <input class="ngaycap" type="text" v-model="employee.Nation" />
            <!-- <div class="invalid-feedback" v-if="errors.ngaycap">
              {{ errors.ngaycap }}
            </div> -->
          </div>
          <div class="input__box">
            <label for="">Tôn giáo</label>
            <input class="noicap" type="text" v-model="employee.Religion" />
            <!-- <div class="invalid-feedback" v-if="errors.tongiao">
              {{ errors.tongiao }}
            </div> -->
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
  </div>

  <!-- thongbao -->
</template>

<script>
// import notifi from "./FormNotifi.vue"
import combobox from "../base/BaseCombobox.vue";
import axios from "axios";
import { useToast } from "vue-toastification";


export default {
  data() {
    return {
      employee: {},
      faculty: {},
      department: {},
      statusEmployee: {},
      certificate: {},
      position: {},
      salary: {},
      formMode: 1,
      isShowNotifi: false,
      // dataItem: [
      //   { id: 1, khoa: "CNTT" },
      //   { id: 2, khoa: "QTKD" },
      //   { id: 3, khoa: "Kinh tế" },
      //   { id: 4, khoa: "Cơ Khí" },
      // ],
      // dataFields: { value: "id", text: "khoa" },
      isShow: false,
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
        khoa: "",
        trangthai: "",
        capbacluong: "",
        phongban: "",
        chungchidaotao: "",
        tinhtrang: "",
        vitri: "",
      },
      error: {
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
  props: ["employeeSL","code", "FormMode","loadData", "employeeId"],
  components: {
    combobox,
    //    notifi
  },
  watch: {
    employeeSL: function(value){
        this.employee=value
        value.DateOfBirth=this.formatDate(value.DateOfBirth)
        this.employee.DateOfBirth=value.DateOfBirth
        this.employee.EmployeeID=value.EmployeeID
    },
    code: function(vl){
        this.employee.EmployeeCode=vl
    },
    FormMode: function(value){
        this.formMode=value
    },
    
  },
  created() {
    this.getDepartment();
    this.getFaculty();
    this.getPosition();
    this.getSalary();
    this.getstatus();
    this.getCerti();
  },
  methods: {
    getNewCode(){
      try {
       
       var me = this;
      
       axios
         .get(
          "https://localhost:7029/api/Employees/NewCode"
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
    addEmployee(){
        var me = this;
        console.log(me.employee);
        me.employee.Gender=parseInt( me.employee.Gender)
      const toast = useToast();
      try {
        axios
          .post("https://localhost:7029/api/Employees", me.employee)
          .then(function (res) {
            console.log("ok", res.data);
            me.employee={}
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
    editEmployee(){
      var me = this;
        console.log(me.employee);
        me.employee.Gender=parseInt( me.employee.Gender)
      const toast = useToast();
      try {
        axios
          .put(`https://localhost:7029/api/Employees/${this.employee.EmployeeID}`, me.employee)
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
      // this.isShowNotifi = true
      this.$emit("hideForm", false);
      // this.desc = {
        
      //   ten: "",
      //   ngaysinh: "",
      //   cmnd: "",
      //   email: "",
      //   sodt: "",
      //   masothue: "",
      //   sotaikhoan: "",
      //   tennganhang: "",
      //   diachi: "",
      //   khoa: "",
      //   trangthai: "",
      //   capbacluong: "",
      //   phongban: "",
      //   daotao: "",
      //   tinhtrang: "",
      //   vitri: "",
      // };
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

    validate() {
      
      if (!this.employee.EmployeeCode) {
        this.errors.manv = " Mã nhân viên không được để trống!";
        this.isValid = false;
      }else{
        this.errors.manv = "";
        this.isValid = true;
      }
     
      if (!this.employee.EmployeeName) {
        this.errors.ten = "Tên nhân viên Không được để trống!";
        this.isValid = false;
      }else{
        this.errors.ten = "";
        this.isValid = true;
      }
      
      if (!this.employee.IdentityNumber) {
        this.errors.cmnd = "CCCD Không được để trống!";
        this.isValid = false;
      }else{
        this.errors.cmnd = "";
        this.isValid = true;
      }
      if (!this.employee.Email) {
        this.errors.email = "Email Không được để trống!";
        this.isValid = false;
      }else{
        this.errors.email = "";
        this.isValid = true;
      }

      if (!this.employee.Adress) {
        this.errors.diachi = "Địa chỉ không được để trống!";
        this.isValid = false;
      }
      // if(!this.employee.Gender) {
      //     this.errors.gioitinh = "Không được để trống!";
      //     this.isValid = false;
      // }
      // if (!this.employee.DateOfBirth) {
      //   this.errors.ngaysinh = "Không được để trống!";
      //   this.isValid = false;
      // }
      // if (!this.employee.IdentityNumber) {
      //   this.errors.cmnd = "Không được để trống!";
      //   this.isValid = false;
      // } else if (!this.isNumber(this.employee.IdentityNumber)) {
      //   this.errors.cmnd = "Yêu cầu nhập số";
      //   this.isValid = false;
      // }
      // if(!this.employee.Phonenumber) {
      //   this.errors.sodt = "Không được để trống!";
      //   isValid = false;
      // } else if(!this.isNumber(this.employee.Phonenumber)) {
      //   this.errors.sodt = "Yêu cầu nhập số";
      //   isValid = false;
      // }else if(this.employee.Phonenumber.length < 10) {
      //   this.errors.sodt = "Không được nhỏ hơn 10 số";
      //   isValid = false;
      // }
      // if (!this.employee.FacultyName) {
      //   this.errors.khoa = "Không được để trống!";
      //   this.isValid = false;
      // }
      
    //   if (!this.employee.masothue) {
    //     this.errors.masothue = "Không được để trống!";
    //     this.isValid = false;
    //   }
    //   if (!this.employee.sotaikhoan) {
    //     this.errors.sotaikhoan = "Không được để trống!";
    //     this.isValid = false;
    //   } else if (!this.isNumber(this.employee.sotaikhoan)) {
    //     this.errors.sotaikhoan = "Yêu cầu nhập số";
    //     this.isValid = false;
    //   }
      // if (!this.employee.Email) {
      //   this.errors.email = "Không được để trống!";
      //   this.isValid = false;
      // } else if (!this.isEmail(this.employee.Email)) {
      //   this.errors.email = "Yêu cầu nhập kiểu email";
      //   this.isValid = false;
      // }
      // if (!this.employee.daotao) {
      //   this.errors.daotao = "Không được để trống!";
      //   this.isValid = false;
      // }
    //   if (!this.employee.tennganhang) {
    //     this.errors.tennganhang = "Không được để trống!";
    //     this.isValid = false;
    //   }
      // if (!this.employee.StatusEmployeeName) {
      //   this.errors.trangthai = "Không được để trống!";
      //   this.isValid = false;
      // }
      // if (!this.employee.SalaryName) {
      //   this.errors.capbacluong = "Không được để trống!";
      //   this.isValid = false;
      // }
      // if (!this.employee.DepartmentName) {
      //   this.errors.phongban = "Không được để trống!";
      //   this.isValid = false;
      // }
      // if (!this.employee.TrainingCertificateName) {
      //   this.errors.chungchidaotao = "Không được để trống!";
      //   this.isValid = false;
      // }
      // if (!this.employee.PositionsName) {
      //   this.errors.vitri = "Không được để trống!";
      //   this.isValid = false;
      // }

    //   var getSelectedValue = document.querySelector(
    //     'input[name="gioitinh"]:checked'
    //   );

    //   if (getSelectedValue != null) {
    //     document.getElementById("disp").innerHTML =
    //       getSelectedValue.value + " season is selected";
    //   }

      // return isValid;
    },
    isNumber(value) {
      return /^\d*$/.test(value);
    },
    isEmail(value) {
      var validRegex =
        /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
      return validRegex.test(value);
    },
    save() {
        if(this.formMode==1){
            this.addEmployee()
        }else{
          this.editEmployee()
        }
      // if(!this.validate()){
      //     console.log(this.employee);
      // }
    //   this.validate();

    //   this.$emit("save",this.desc)

      //    console.log(this.desc)
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
          .get("https://localhost:7029/api/Departments")
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
          .get("https://localhost:7029/api/Position")
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
          .get("https://localhost:7029/api/Salary")
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
          .get("https://localhost:7029/api/TranningCertification")
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
          .get("https://localhost:7029/api/StatusEmployee")
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
          .get("https://localhost:7029/api/Faculty")
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
      this.employee.FacultyID = value.FacultyID;
      this.employee.FacultyName = value.FacultyName;
    },
  },
};
</script>
<style>
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
  border-radius: 8px;
  width: 800px;
  /* display: none; */
}
.form-Wrap {
  padding: 0 20px;
}
.form-title {
  padding: 0 13px;
  background-color: #d9d9d9;
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 0px;
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
  padding: 8px;
  background-color: #d9d9d9;
  gap: 28px;
  margin-top: 2px;
}
.btn-cancel {
  background-color: #fff;
}
.btn-save {
  background-color: #1a8fdd;
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
 /* .khoa {
    margin-top: 4px;
  } */
  .important {
    color: red;
  }
</style>
