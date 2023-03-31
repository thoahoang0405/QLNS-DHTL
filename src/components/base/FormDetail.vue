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
            <label for="">Mã sinh viên <span class="important">*</span></label>
            <input @blur="validateStudentCode" class="masv" :class="errors.masv!=''? 'borderRed' : ''" type="text" v-model="students.StudentCode" />
            <div class="invalid-feedback" v-if="errors.masv">
              {{ errors.masv }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Tên sinh viên <span class="important">*</span></label>
            <input @blur="validateName" :class="errors.ten!=''? 'borderRed' : ''" type="text" v-model="students.StudentName" />
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
                v-model="students.Gender"
                value="0"
              />
              <label class="nam" for="">Nam</label>
              <input type="radio" id="nu" v-model="students.Gender" value="1" />
              <label class="nu" for="">Nữ</label>
            </div>
            <div class="invalid-feedback" v-if="errors.gioitinh">
              {{ errors.gioitinh }}
            </div>
            <!-- <div style= "color:red" id="disp">{{ desc.gioitinh }}</div> -->
          </div>
        </div>

        <div class="column">
          <div class="input__box">
            <label for="">Ngày sinh <span class="important">*</span></label>
            <input
            @blur="validateDateOfBirth" :class="errors.ngaysinh!=''? 'borderRed' : ''"
              type="date"
              v-model="students.DateOfBirth"
            />
            <div class="invalid-feedback" v-if="errors.ngaysinh">
              {{ errors.ngaysinh }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Cmnd/cccd <span class="important">*</span></label>
            <input @blur="validateIdentity" :class="errors.cmnd!=''? 'borderRed' : ''" type="text" v-model="students.IdentityNumber" />
            <div class="invalid-feedback" v-if="errors.cmnd">
              {{ errors.cmnd }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Email <span class="important">*</span></label>
            <input @blur="validateEmail" :class="errors.email!=''? 'borderRed' : ''" type="text" v-model="students.Email" />
            <div class="invalid-feedback" v-if="errors.email">
              {{ errors.email }}
            </div>
</div>
          <div class="input__box">
            <label for="">Số điện thoại</label>
            <input class="sodt" type="text" v-model="students.Phonenumber" />
            <div class="invalid-feedback" v-if="errors.sodt">
              {{ errors.sodt }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Số tài khoản</label>
            <input
              class="sotaikhoan"
              type="text"
              v-model="students.BankAccountNumber"
            />
            <div class="invalid-feedback" v-if="errors.sotaikhoan">
              {{ errors.sotaikhoan }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Tên ngân hàng</label>
            <input
              class="tennganhang"
              type="text"
              v-model="students.BankAccountName"
            />
            <div class="invalid-feedback" v-if="errors.tennganhang">
              {{ errors.tennganhang }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Địa chỉ</label>
            <input class="diachi" type="text" v-model="students.Adress" />
            <div class="invalid-feedback" v-if="errors.diachi">
              {{ errors.diachi }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Khoa</label>
            <combobox
              class="khoa"
              :value="students.FacultyName"
              :items="faculty"
              :code="'FacultyID'"
              :fieldName="'FacultyName'"
              @selectedItem="selectItemFaculty"
            ></combobox>
            <!-- <combobox class="khoa " v-model="desc.khoa"></combobox> -->
            <!-- <input class="khoa" type="text" v-model="desc.khoa"> -->
            <div class="invalid-feedback khoa" v-if="errors.khoa">
              {{ errors.khoa }}
            </div>
          </div>
          <div class="input__box">
            <label for="">Lớp</label>
            <input class="lop" type="text" v-model="students.Class" />
            <div class="invalid-feedback" v-if="errors.lop">
              {{ errors.lop }}
            </div>
          </div>
        </div>

        <div class="column column-s">
          <div class="input__box">
            <label for="">Chương trình đào tạo</label>
            <combobox
              class="chuongtrinhdaotao"
              :value="students.EducationProgramName"
              :items="educationProgram"
              :code="'EducationProgramID'"
              :fieldName="'EducationProgramName'"
              @selectedItem="selectItemEducationProgramName"
            ></combobox>
          </div>
<div class="input__box">
            <label for="">Xếp loại</label>
            <combobox
              class="xeploai"
              :value="students.ClassificationName"
              :items="classification"
              :code="'ClassificationID'"
              :fieldName="'Classification'"
              @selectedItem="selectItemClassification"
            ></combobox>
            <!-- <div class="invalid-feedback" v-if="errors.xeploai">
              {{ errors.xeploai }}
            </div> -->
          </div>
          <div class="input__box">
            <label for="">Trạng thái</label>
            <combobox
              class="trangthai"
              :value="students.StatusName"
              :items="statusname"
              :code="'StatusStudentID'"
              :fieldName="'StatusStudentName'"
              @selectedItem="selectItemStatusName"
            ></combobox>
          </div>
          <!-- <div class="input__box">
                        <label for="">Trạng thái</label>
                        <input class="trangthai" type="text" v-model="desc.trangthai">
                        <div class="invalid-feedback" v-if="errors.trangthai">{{ errors.trangthai }}</div>
                    </div> -->
        </div>
      </div>
      <div class="form-bottom">
        <div class="btn btn-cancel" @click="closeForm">Hủy</div>
        <div class="btn btn-save" @click="save">Lưu</div>
      </div>
    </form>

    <!-- Notification -->

    <notifi
      v-show="isShowNotifi"
      @closeNotifi="closeNo"
      @cancelNotifi="cancelForm"
    ></notifi>
  </div>
</template>

<script>
import notifi from "./FormNotifi.vue";
import axios from "axios";
import combobox from "../base/BaseCombobox.vue";
import { useToast } from "vue-toastification";

// import { useToast } from "vue-toastification";
export default {
  data() {
    return {
        department: {},
        formMode: 1,
        faculty: {},
        isValid: false,
        classification: {},
        educationProgram: {},
        statusname: {},
      isShowNotifi: false,
    //   dataItem: [
    //     { id: 1, khoa: "CNTT" },
    //     { id: 2, khoa: "QTKD" },
    //     { id: 3, khoa: "Kinh tế" },
    //     { id: 4, khoa: "Cơ Khí" },
    //   ],
    //   dataFields: { value: "id", text: "khoa" },
      students: {},
      errors: {
        masv: "",
        ten: "",
        gioitinh: "",
        ngaysinh: "",
        cmnd: "",
        email: "",
        sodt: "",
        khoa: "",
        sotaikhoan: "",
        tennganhang: "",
        diachi: "",
        // khoa: '',
        lop: "",
        daotao: "",
        xeploai: "",
        trangthai: "",
      },
    };
  },
  props: ["student", "code", "FormMode", "loadData"],
  created() {
    this.getFaculty();
    this.getStatus();
    this.getEducationProgram();
    this.selectItemClassification();
    this.getNewCode();
  },
  watch: {
    student: function (value) {
      this.students = value;
value.DateOfBirth=this.formatDate(value.DateOfBirth)
        this.students.DateOfBirth=value.DateOfBirth
        this.students.EmployeeID=value.EmployeeID
     
  
    },
    code: function (vl) {
      this.students.StudentCode = vl;
    },
    FormMode: function (value) {
      this.formMode = value;
    },
  },
  components: {
    combobox,
    notifi,
  },
  methods: {
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
    getFaculty() {
      try {
        var me = this;

        axios
          .get("https://localhost:7029/api/Faculty")
          .then(function (res) {
            //gán kqua vào object faculty
            me.faculty = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    getEducationProgram() {
      try {
        var me = this;

        axios
          .get("https://localhost:7029/api/EducationProgram")
          .then(function (res) {
            me.educationProgram = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    selectItemClassification() {
      try {
        var me = this;

        axios
          .get("https://localhost:7029/api/Classifications")
          .then(function (res) {
            me.classification = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    getStatus() {
      try {
        var me = this;

        axios
          .get("https://localhost:7029/api/StatusStudent")
          .then(function (res) {
            me.statusname = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    getNewCode() {
      try {
        var me = this;

        axios
          .get("https://localhost:7029/api/Students/NewCode")
          .then(function (res) {
            me.students.StudentCode = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    addStudent() {
      var me = this;
      console.log(me.students);
      me.students.Gender = parseInt(me.students.Gender);
      const toast = useToast();
     
         try {
        axios
          .post("https://localhost:7029/api/Students", me.students)
          .then(function (res) {
            console.log("ok", res.data);
           
            me.students = {};
            me.getNewCode();
            toast.success("thêm dữ liệu thành công", { timeout: 2000 });
            me.loadData();
          })

          .catch(function () {
            // this.validate();
            toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
      
     
    },
    editStudent() {
      var me = this;
      console.log(me.students);
      me.students.Gender = parseInt(me.students.Gender);
      const toast = useToast();
      try {
        axios
          .put(`https://localhost:7029/api/Students/${this.students.StudentID}`, this.students)
          .then(function (res) {
            console.log("ok", res.data);
            me.$emit("hideForm", false);
            toast.success("sửa dữ liệu thành công", { timeout: 2000 });
            me.loadData();
          })

          .catch(function () {
            // this.validate();
            toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    selectItemFaculty(value) {
      this.students.FacultyName = value.FacultyName;
    },
    selectItemStatusName(value) {
      this.students.StatusName = value.StatusName;
    },
    selectItemEducationProgramName(value) {
      this.students.EducationProgramName = value.EducationProgramName;
    },
    btnHidden() {
      this.isShow = !this.isShow;
    },
    closeNo(value) {
      this.isShowNotifi = value;
    },
    cancelForm(value) {
      this.isShowNotifi = value;
      this.$emit("hideForm", false);
    },
    // gửi lệnh ẩn form từ bên này sang trang chính
    closeForm() {
      // this.$emit("hideForm", false);
      this.$emit("hideForm", false);
    },

    validateStudentCode() {
      
      if (!this.students.StudentCode) {
        this.errors.masv = " Mã sinh viên không được để trống!";
        this.isValid=false
       
      }else{
        this.isValid=true
        this.errors.masv = "";
       
      }
      },
    validateName() {
      if (!this.students.StudentName) {
        this.errors.ten = "Tên sinh viên Không được để trống!";
       this.isValid=false
        // document.getElementsByClassName('ten').classList.add('borderRed')
      }else{
        this.isValid=true
        this.errors.ten = "";
      }
    },
    validateDateOfBirth(){
    if (this.students.DateOfBirth) {
        this.students.DateOfBirth = new Date(this.students.DateOfBirth) 
        if (this.students.DateOfBirth > new Date() && this.students.DateOfBirth) {
        this.isValid=false
        this.errors.ngaysinh="Ngày sinh không được lớn hơn ngày hiện tại!"
     
      }else{
        this.isValid=true
      }  
      }
      
    },
    getAllStudent(){
      try {
        var me = this;

        axios
          .get("https://localhost:7029/api/Students")
          .then(function (res) {
          
            for (const item of res.data) {
            
             if(me.students.StudentCode==item.StudentCode){
              this.isValid=false
              me.isShowPop=!me.isShowPop
             
             }else{
              this.isValid=true
             }
            }
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
     },
    validateIdentity() {
      if (!this.students.IdentityNumber) {
        this.isValid=false
        this.errors.cmnd = "CCCD Không được để trống!";
       
      }else{
        this.isValid=true
        this.errors.cmnd = "";
       
      }
    },
    validateEmail() {
      if (!this.students.Email) {
        this.errors.email = "Email Không được để trống!";
       
      }
      else if ((this.students.Email)&&(!this.isEmail(this.students.Email))){
        this.errors.email = "Email Không đúng định dạng!";
       
      }else{
        this.errors.email = "";
       
      }
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
        this.getAllStudent()
        this.validateStudentCode()
        this.validateName()
        this.validateEmail()
        this.validateIdentity()
        this.validateDateOfBirth()
        console.log(this.isValid);
     if(this.isValid==true){
        if (this.formMode == 1) {
        this.addStudent();
        }else{
          this.editStudent()
        }
     }
    
      
     

      
      // const toast = useToast();
      // this.$emit("hideForm", false);
      // toast.success("Thêm dữ liệu thành công", { timeout: 2000 });
    //   this.validate();
      // this.$emit("save", this.desc);
      // console.log(this.desc);
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

    // selectItemStatusName(value) {
    //     /**
    //      * object employee ở đâu 
    //      * phần này vào db 2 bảng student với statusStudent xem lại cột
    //      */
    //   this.students.StatusNameID = value.StatusNameID;
    //   this.students.StatusName = value.StatusName;
    // },
  },
};
</script>
<style>
label {
  margin: 10px 0;
}
.borderRed{
  border: 1px solid red;
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
  width: 800px;
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
  background-color: #d9d9d9;
  gap: 28px;
  margin-top: 14px;
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
/* .khoa {
    margin-top: 4px;
  } */
.important {
  color: red;
}
</style>