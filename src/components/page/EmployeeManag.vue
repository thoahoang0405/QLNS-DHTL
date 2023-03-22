<template>
  <div class="body">
    <h3 class="header-bd">Quản lý sinh viên</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search"   v-model="txtSearch"  @keypress.enter="getPagingEmployee"  placeholder="Tìm kiếm sinh viên" />
          <div class="icon-search icon"></div>
        </div>
        
        <Combobox
          :items="department"
         
          :fieldName="'DepartmentName'"
         
          @selectedItem="selectItemCbb"
        ></Combobox>
      
        <Combobox
          :items="position"       
          :fieldName="'PositionsName'"
          @selectedItem="selectItemCategory"
         
        ></Combobox>
      </div>
      <div class="button-function">
        <div class="add">
          <button @click="btnShow" class="btn-add btn-hover-blue">+ Thêm nhân viên</button>
        </div>

        <button @click="getPagingEmployee" class="btn-excel">
          <div class="icon icon-load">
            <div class="tooltip-excel">Lấy lại dữ liệu</div>
          </div>
        </button>
        
      </div>
    </div>
    <div id="m-table" class="m-table">
      <table id="tbEmployee" class="table">
        <thead>
          <tr>
            <th
              class="sticky-left-top checkbox"
              colspan="1"
              style="min-width: 30px !important; text-align: center"
            >
              <input
                ref="checkall"
                type="checkBox"
                class="check-all"
                style="width: 18px; height: 18px"
              />
            </th>
            <th class="text-center" style="min-width: 40px;">STT</th>
            <th>Mã nhân viên</th>
              <th>Họ và tên</th>
              <th>Giới tính</th>
              <th>Ngày sinh</th>
              <th>Số CMND/CCCD</th>
              <th>Email</th>
              <th>Số điện thoại</th>
              <th>Mã số thuế</th>
              <th>Số tài khoản</th>
              <th>Tên ngân hàng</th>
              <th>Địa chỉ</th>
              <th>Khoa</th>
              <th>Trạng thái</th>
              <th>Cấp bậc lương</th>
              <th>Phòng ban</th>
              <th>Chứng chỉ đào tạo</th>
              <th>Tình trạng hôn nhân</th>
              <th>Vị trí</th>
              
            <th
              class="th-item-final sticky-right-top"
              colspan="12"
              style="min-width: 100px; text-align: center"
            >
              <div class="th-item">
                <span class="table-text">Chức năng </span>
              </div>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr ref="row" v-for="(emp, index) of employees" :key="emp.EmployeeCode">
            <td
              ref="rowCheck"
              class="checkbox sticky-left"
              style="text-align: center"
              colspan="1"
            >
              <input
                ref="check"
                class="check-item"
                type="checkbox"
                style="width: 18px; height: 18px"
              />
            </td>
            <td class="text-center">{{ index+1 }}</td>
            <td>{{ emp.EmployeeCode }}</td>
            <td>{{ emp.EmployeeName }}</td>
            <td>{{ gender(emp.Gender) }}</td>
            <td>{{ formatDate(emp.DateOfBirth) }}</td>
            <td>{{ emp.IdentityNumber }}</td>
            <td>{{ emp.Email }}</td>
            <td>{{ emp.Phonenumber }}</td>
            <td>{{ emp.TaxCode }}</td>
            <td>{{ emp.BankAccountNumber }}</td>
            <td>{{ emp.BankAccountName }}</td>
            
            <td>{{ emp.Adress }}</td>
            <td>{{ emp.FacultyName }}</td>
            <td>{{ emp.StatusEmployeeName }}</td>
            <td>{{ emp.SalaryName }}</td>
            <td>{{ emp.DepartmentName }}</td>
            <td>{{ emp.TrainingCertificateName}}</td>
            <td>{{ emp.MaritalStatus }}</td>
            <td>{{ emp.PositionsName }}</td>
           
            <td
              ref="func"
              class="td-item-final td-func sticky-right"
              style="position: sticky; right: 0; background-color: #fff"
              colspan="12"
            >
              <div class="edit-text"></div>
              <div class="icon icon-edit" @click="editEmployee(emp)" ></div>
                <div class="icon icon-delete" @click="deleteEmployee(emp)"></div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="paging">
      <div class="paging-left">
        Tổng số:
        <strong>{{ totalRecord }}</strong>
        bản ghi
      </div>
      <div class="paging-right">
        <div class="page">
          <div class="content-page">{{ pageDefault }} bản ghi trên 1 trang</div>
          <div class="dropup-page">
            <div class="icon-dropup" @click="btnDropUp"></div>
            <div class="item-up" v-show="isShowDrop">
              <div
                class="item-dropup"
                :class="{ act: isActive == '10' }"
                pageSize="10"
                
                @click="getPageDefault"
              >
                10 bản ghi trên 1 trang
              </div>
              <div
                class="item-dropup"
                :class="{ act: isActive == '20' }"
                pageSize="20"
                @click="getPageDefault"
                :value="pageDefault"
              >
                20 bản ghi trên 1 trang
              </div>
              <div
                class="item-dropup"
                :class="{ act: isActive == '30' }"
                pageSize="30"
                @click="getPageDefault"
              >
                30 bản ghi trên 1 trang
              </div>
              <div
                class="item-dropup"
                :class="{ act: isActive == '50' }"
                pageSize="50"
                @click="getPageDefault"
              >
                50 bản ghi trên 1 trang
              </div>
              <div
                class="item-dropup"
                :class="{ act: isActive == '100' }"
                pageSize="100"
                @click="getPageDefault"
              >
                100 bản ghi trên 1 trang
              </div>
            </div>
          </div>
        </div>
        <div>
          <Paginate
          v-model="page"
                    :page-count="totalPage"
                    :page-range="2"
                    :margin-pages="1"
                    :click-handler="clickCallback"
                    :prev-link-class="'page-link'"
                    :prev-text="'Trước'"
                    :prev-class="'page-item'"
                    :next-link-class="'page-link'"
                    :next-text="'Sau'"
                    :next-class="'page-item'"
                    :container-class="'pagination'"
                    :page-class="'page-item'"
          >
          </Paginate>
        </div>
      </div>
    </div>
  </div>
  <popUp v-show="isShowPopup" :msv="empCodeDelete" @closeNotifi="deleteEmp"></popUp>
<Form v-show="isShow" @hideForm="closeForm" :loadData="getPagingEmployee" :employeeId="employeeID"  :FormMode="formMode" :employeeSL="employeeSelect" :code="newCode"></Form>
<!-- <div id="load" ></div> -->
</template>
<style>
@import url('../../css/page/loading.css');
  .btn-add:hover {
    opacity: 0.8;
  }
  .border-red {
  border: 1px solid red;
  }
 
</style>
<script>
import Paginate from "vuejs-paginate-next";
import axios from "axios";
import Form from "../base/FormEmployee.vue"
import $ from "jquery";
import Combobox from "../base/BaseCombobox2.vue";
import popUp from "../base/BasePopupDelete.vue"
import { useToast } from "vue-toastification";

export default {
  components: {
    Paginate,Form,Combobox,popUp
  },
  data() {
    return {
      isActive: "20",
      pageNumber: 1,
      page: 1,
      employees:{},
      totalPage: 1,
      isShow: false, //gán v-show=isShow hoặc v-show =false để ẩn form
      isShowDrop: false,
      totalRecord: 0,
      pageDefault: 20,
      department:{},
      isShowLoad:false,
      position:{},
      departmentID:"",
      positionID:"",
      txtSearch:"",
      employeeSelect:{},
      newCode: "",
      formMode: 1,
      employeeID:"",
      isShowPopup:false,
      empCodeDelete:"",
      empID:""
    };
  },
  created() {
    this.getPagingEmployee()
    this.getDepartment()
    this.getPosition()
  },
  watch: {
    txtSearch: function () {
      if (this.txtSearch == "") {
        this.getPagingEmployee();
      }
    },
  },
  methods: {
    deleteEmployee(emp){
      this.isShowPopup=!this.isShow
      this.empCodeDelete= emp.EmployeeCode
      this.empID=emp.EmployeeID
    },
    deleteEmp(value){
      this.isShowPopup=value
      var me = this;
      const toast = useToast();
      try{
       axios
         .delete(
          `https://localhost:7029/api/Employees/${me.empID}`
         )
         .then(function (res) {
          console.log(res);
          toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
          me.getPagingEmployee()
         })
        
         .catch(function () {
          toast.error("xóa dữ liệu thất bại", { timeout: 2000 });
           console.log(1);
         });
     } catch (error) {
       console.log(error);
     }
    },
    editEmployee(emp){
      this.employeeSelect=emp
      this.employeeID=emp.EmployeeID
     this.isShow=true
     this.formMode=2
    },
    getPagingEmployee() {
      try {
       
        var me = this;
       me.isShowLoad=true
        axios
          .get(
            `https://localhost:44301/api/Employees/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&departmentID=${this.departmentID}&positionID=${this.positionID}&pageNumber=${this.pageNumber}`
          )
          .then(function (res) {
          
            me.totalPage = res.data.TotalPages;
            me.totalRecord = res.data.TotalRecords;
            me.employees = res.data.Data;
            console.log( me.totalPage);
            console.log(me.employees);
            me.isShowLoad=false
            
          })
         
          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    getDepartment(){
      try {
       
       var me = this;
      
       axios
         .get(
          "https://localhost:44301/api/Departments"
         )
         .then(function (res) {
          me.department=res.data
         })
        
         .catch(function () {
           console.log(1);
         });
     } catch (error) {
       console.log(error);
     }

    },
    getPosition(){
      try {
       
       var me = this;
      
       axios
         .get(
          "https://localhost:44301/api/Position"
         )
         .then(function (res) {
          me.position=res.data
         })
        
         .catch(function () {
           console.log(1);
         });
     } catch (error) {
       console.log(error);
     }

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
          return `${newDate}-${month}-${year}`;
        }
      } catch (error) {
        return "";
      }
    },
    selectItemCbb(value) {
    
      if (value.DepartmentID) {
        this.departmentID = value.DepartmentID;
      } else {
        this.departmentID = "";
        this.getPagingEmployee();
      }
      this.getPagingEmployee();
     
    },
    selectItemCategory(value) {
      console.log(value.PositionsID);
      if (value.PositionsID) {
        this.positionID = value.PositionsID;
        
      } else {
        this.positionID= "";
        this.getPagingEmployee();
      }
      this.getPagingEmployee();
    },
    showPage(is) {
      this.isShowDrop = is;
    },
    btnShow(){
      this.employeeSelect={}
      this.getNewCode()
      this.formMode=1;
      this.isShow = !this.isShow
    },
    
    getNewCode(){
      try {
       
       var me = this;
      
       axios
         .get(
          "https://localhost:44301/api/Employees/NewCode"
         )
         .then(function (res) {
          me.newCode=res.data
         })
        
         .catch(function () {
           console.log(1);
         });
     } catch (error) {
       console.log(error);
     }
    },
    //nhận lệnh ẩn từ bên form chi tiết
    closeForm(value){
      this.isShow=value
    },
    btnDropUp() {
      $(".icon-dropup").toggleClass("iconrotate");
      if (!this.isShowDrop) {
        this.showPage(true);
        $(".icon-dropup").addClass("iconrotate");
      } else {
        this.showPage(false);
        $(".icon-dropup").removeClass("iconrotate");
      }
    },
    gender(gender){
      switch (gender) {
        case 0:
          gender="Nam"
          break;
          case 1:
            gender="Nữ"
          break;
        default:
          break;
      }
      return gender;
    },
    
    getPageDefault(e) {
      this.isActive = e.target.getAttribute("pageSize");
      this.pageDefault = e.target.getAttribute("pageSize");
      this.showPage(false);
      $(".icon-dropup").removeClass("iconrotate");
      this.getPagingEmployee()
      if (this.pageDefault > this.totalRecord) {
        this.pageDefault = this.totalRecord;
      }
    },

    clickCallback(pageNum) {
      this.pageNumber = pageNum;
      this.getPagingEmployee()
    },
  },
};
</script>
