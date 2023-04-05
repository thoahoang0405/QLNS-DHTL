<template>
  <div class="popup-bonus">
    <div class="bonus-form">
      <div class="head-popup">
        <h3 class="title-heading">Chi tiết lương</h3>
        <div class="btn-close-popup">
          <div class="icon" @click="closeForm">
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
              stroke="currentColor" class="w-6 h-6">
              <path stroke-linecap="round" stroke-linejoin="round"
                d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
            </svg>
          </div>
        </div>
      </div>

      <div class="education-header">
        <div class="maNV">Mã nhân viên: {{ maNV }}</div>
        <div class="tenNV">Tên nhân viên: {{ tenNV }}</div>
        <div class="tenNV">Ngày sinh: {{ formatDate(ngaySinh) }}</div>
        <div class="tenNV">Tên Khoa: {{ khoa }}</div>
        <div class="btnWrap">
          <div class="btnAdd" @click="btnAddClick">Thêm</div>
          <!-- <div class="btnEdit">Sửa</div> -->
        </div>
      </div>
      <div id="table-dt">
        <div class="table-dt">

          <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
            <tr>
              <th>Chức Vụ</th>
              <th>Hệ số lương</th>
              <th>Ngạch lương</th>
              <th>Tên phụ cấp</th>
              <th>Giá trị phụ cấp</th>
              <th>BHYT(%)</th>
              <th>BHXH(%)</th>
              <th>Phần trăm hưởng lương</th>
              <th>Tháng nhận</th>
              <th>Năm nhận</th>
              <th style="width:100px;">Chức năng</th>
            </tr>
            <tr>
            </tr>
            <tr v-for="item of SalaryDetail" :key="item.IDLuong">
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.TenCVHT }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.HeSoLuong }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.MaNgachLuong }}</td>

              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.TenPhuCap }}</td>

              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.GiaTriPhuCap }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.BHYT }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.BHXH }}</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.PhanTramHuongLuong }}</td>

              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.Thang }}</td>

              <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.Nam }}</td>

              <td ref="func" class="td-item-final td-func"
                style="background-color: #fff; align-items: center; border: 1px solid #c7c7c7; column-gap: 10px;"
                colspan="12">
                <div class="icon icon-edit" @click="onClickEdit(item)"></div>
                <div class="icon icon-delete" @click="onClickDelete(item)"></div>
              </td>
            </tr>
          </table>
        </div>
      </div>

    </div>
  </div>
  <!-- <Notifi
      v-show="isShowAddFos"
      @closeNotifi="closeNo"
      @cancelNotifi="cancelFormAddFos"
    ></Notifi>-->
  <popUp v-show="isShowPopup" :msv="mess" @cancelNotifi="noDelete" @closeNotifi="deleteOK"></popUp>
  <Form v-if="isShowForm" :salarySL="salarySelected" @loadData="getSalaryByID" :IDNV="idNV" @hideFormAdd="closeFormAdd"
    :FormMode="formMode" :title="titleForm"></Form>
</template>
<script>
import axios from 'axios'
import Form from "./FormSalary.vue"
import PopUp from './BasePopupDelete2.vue'
import { useToast } from "vue-toastification";
export default {
  data() {
    return {
      isShowPopup: false,
      SalaryDetail: {},
      id: "",
      isShowForm: false,
      formMode: 0,
      titleForm: "",
      salarySelected: {},
      idDelete: "",
      mess: "",
    }
  },
  props: ["ngaySinh", "idNV", "maNV", "tenNV", "khoa", "salarySl"],
  components: {
    Form, PopUp
  },
  watch: {
    // salarySl: function(value){
    //   this.SalaryDetail=value
    //   console.log(value);
    // },
    idNV: function (value) {
      this.id = value
      console.log(value);
    }
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
          return `${newDate}-${month}-${year}`;
        }
      } catch (error) {
        return "";
      }
    },
    loadData() {
      this.getSalaryByID()
      this.$emit("Load")
    },
    onClickDelete(item) {
      this.isShowPopup = !this.isShowPopup
      this.idDelete = item.IDLuong
      this.mess = "Bạn có chắc chắn muốn xóa thông tin lương này không?"
    },
    noDelete() {
      this.isShowPopup = false
    },
    deleteOK() {
      this.isShowPopup = false
      var me = this;
      const toast = useToast();
      try {
        axios
          .delete(
            `https://localhost:44301/api/luong/${me.idDelete}`
          )
          .then(function (res) {
            console.log(res);
            toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
            me.getSalaryByID()
          })

          .catch(function () {
            toast.error("xóa dữ liệu thất bại", { timeout: 2000 });
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    onClickEdit(item) {
      this.salarySelected = item
      this.isShowForm = !this.isShowForm
      this.formMode = 1
      this.titleForm = "Sửa lương"
    },
    btnAddClick() {
      this.isShowForm = !this.isShowForm
      this.formMode = 0
      this.titleForm = "Thêm mới lương"
    },
    closeFormAdd(value) {
      this.isShowForm = value
    },
    closeForm() {
      this.$emit("hideForm", false)
    },
    getSalaryByID() {
      try {

        var me = this;
        console.log(this.id);
        console.log(this.idNV);
        axios
          .get(
            `https://localhost:44301/api/luong/${this.idNV}`
          )
          .then(function (res) {


            me.SalaryDetail = res.data
            console.log(me.SalaryDetail);


          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }

    },
  },
  created() {
    this.getSalaryByID()
  },
}
</script>
<style scoped>
.btnAdd {
  padding-top: 10px !important;
  height: 38px;
  box-sizing: border-box;
  align-items: center;
  text-align: center;
  padding: 8px 0px;
}

#table-dt {
  background-color: #fff;
  height: calc(100% - 130px);

  width: 100%;
  overflow-x: scroll;
  margin: 10px 0px;
}

table,
:target {
  border: none;

  background-color: white;
  margin-top: 0px;
}

table[data-v-0e273c10],
tr[data-v-0e273c10] {
  padding: 0px 0px 5px 0px;
}

th {
  border-bottom: 1px solid #c7c7c7;
  border-right: 1px dotted #c7c7c7;
  text-align: left;
  padding: 0px 10px;
  height: 35px;
  box-sizing: border-box;
}

table {
  width: 90%;
}

.btnSave {
  width: 85px;
  border: 1px solid;
  text-align: center;
  padding: 5px;
  border-radius: 5px;
  color: #fff;
  background-color: #5d82e0;
  position: absolute;
  right: 40px;
  bottom: 20px;
}

.btnSave:hover {
  border: 1px solid #7EA1F9;
  color: #000;
  background-color: #fff;
}

.column input {
  width: 80%;
}

.input__box {
  display: flex;
  justify-content: space-between;
}

.title-heading {
  text-align: center;
  width: 100%;
  font-size: 18px;
}

.education-header {
  font-weight: 600;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.btnWrap {
  display: flex;
  column-gap: 10px;
}

.btnAdd,
.btnEdit {
  padding: 3px 25px;
  background: #7EA1F9;
  border-radius: 5px;
  color: #fff;
}

.btnAdd:hover {
  background-color: #fff;
  color: #000;
  border: 1px solid #7EA1F9;
}

ul.pagination {
  display: flex;
  color: #111;
  list-style-type: none;
}

th {
  border-bottom: 1px solid #c7c7c7;
  border-right: 1px dotted #c7c7c7;
  text-align: left;
  padding: 0px 10px;
  height: 35px;
  box-sizing: border-box;
}

td {
  border-bottom: 1px solid #c7c7c7;
  border-right: 1px dotted #c7c7c7;
  padding: 0px 10px;
  text-align: left;
  height: 44px;
  box-sizing: border-box;
}

ul.pagination a {
  text-decoration: none;
  color: #111;
  width: 200px;
}

.content-page {
  min-width: 170px;
  margin-left: 6px;
  margin-right: 10px;
  margin-top: 9px;
  position: relative;
}

.page-link {
  margin: 5px;
}

.paging-left {
  color: #111;
  margin-left: 5px;
  margin-top: 20px;


  text-align: center;
}

.page-item:first-child {


  color: #727272;
}

.page-item:last-child {

  color: #727272;
}

.text-center {
  align-items: center;
  padding-top: 13px;
}

.page-item {
  margin: 5px;
  width: 20px;
  height: 20px;
  display: flex;
  align-items: center;
  text-align: center;
  cursor: pointer;
  padding: 0;
  justify-content: center;
}

li.page-item.disabled {
  color: #bbb;
}

.page-item.active {
  font-weight: 700;
  text-align: center;
  background-color: #eeeaea;
  color: #000;
}

.page-item.active a {
  width: 20px;
  text-align: center;
}

.before-text {
  color: rgb(104, 102, 102);
  margin: 8px;
  margin-top: 10px;
}

.after-text {
  color: #111;
  margin: 8px;
  margin-top: 10px;
}

.page {
  margin-top: 10px;
  margin-right: 20px;
}

table {
  width: 90%;
}

table,
tr {
  border: none;
  padding: 0px 5px 5px 5px;
  background-color: white;
  margin-top: 0px;
}

td {
  border: none;
  background-color: white;
  margin-top: 0px;
}

tbody tr td {
  color: #111;
  border-bottom: 1px solid #c7c7c7;
  border-right: 1px dotted #c7c7c7;
}

.width-half {
  width: 50%;
}

.color-red {
  color: red;
}

.btn-action:hover {
  background: #74bbd4;
}

.btn-action {
  width: 100px;
  height: 50px;
  background: #3a98b9;
  margin-right: 10px;
  border: none;
  color: white;
  font-weight: bold;
  border-radius: 10px;
}

.btn-group {
  text-align: center;
}

.w-full {
  width: 100%;
  height: 35px;
}

.mask {
  position: relative;
  background-color: rgba(0, 0, 0, 0.5);
}

.popup-bonus {
  position: absolute;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgb(17 17 17 / 16%);
  z-index: 3;
  /* position: fixed;
  display: flex; */
  cursor: pointer;
  /* height: 600px; */
}

.action-form {
  padding: 0px 20px;
  position: absolute;
  width: 68vw;
  height: 550px;
  /* height: auto; */

  top: 10%;
  right: 20%;
  z-index: 99999;
  border-radius: 20px;
  box-shadow: 5px 5px 5px;
  background-color: #fff;

}

.bonus-form {
  padding: 0px 20px;
  position: absolute;
  width: 80vw;
  height: 550px;
  /* height: auto; */

  top: 10%;
  right: 10%;
  z-index: 99999;
  border-radius: 20px;
  box-shadow: 5px 5px 5px;
  background-color: #fff;
}

.head-popup {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: white;
  margin-bottom: 0 !important;
  margin-top: 10px;
  width: 96%;
  margin-left: 4px;
}

svg:hover {
  color: red;
}

.btn-close-popup::hover {
  color: red !important;
}

input {
  width: 300px;
}

table[data-v-07d000ee],
tr[data-v-07d000ee],
td[data-v-07d000ee] {
  border: none;
  padding: 0px 0px 5px 5px;
  margin-bottom: 5px;
  margin-top: 0px;
  margin-left: 4px;

}

.sticky-right-top {
  position: sticky;
  z-index: 0;
  right: 0;
  top: 0;
  background-color: #e5e8ec;
}

.sticky-left-top {
  position: sticky;
  z-index: 0;
  left: 0;
  top: 0;
  background-color: #e5e8ec;
}

thead tr {
  background-color: #e5e8ec;
}

/* .dis,
.bonus{
padding: 2px 6px;
font-size: 11px;
height: 30px;
box-sizing: border-box;
min-width: 80px;
margin-right: 4px;
border-radius: 2.5px;
color: #f5f2f2;
border: none;
margin-top: 2px;
}
.bonus {
background-color: #0cc71b;
}
.dis {
background-color: #426cf7;

}
.bonus:hover{
background-color: #ffff;
color: #0fdb20;
border: 1px solid #0fdb20;
} */

/* .dis:hover{
background-color: #ffff;
color: #426cf7;
border: 1px solid #426cf7;
} */
.desc {
  color: red;
  cursor: pointer;
  font-weight: 600;
}

.desc:hover {
  text-decoration: underline;
}

tbody tr:hover .checkbox,
tbody tr:hover .td-item-final {
  background-color: #fff !important;
}

.btnCancel {
  color: red;

  position: absolute;
  right: 150px;
  border: 1px solid red;
  bottom: 20px;
}

.btnCancel:hover {
  background-color: red;
  color: #fff;

}</style>