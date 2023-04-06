<template>
  <div class="body">

    <h3 class="header-bd">Quản lý lương</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search" v-model="txtSearch" @keypress.enter="getPagingSalary"
          placeholder="Tìm kiếm"/>
          <div class="icon-search icon"></div>
        </div>
        <div class="input">
          <input type="text" class="search" v-model="year" @keypress.enter="getPagingSalary" placeholder="Nhập năm " />
          <div class="icon-filter icon"></div>
        </div>
        <div class="input">
          <input type="text" class="search" v-model="month" @keypress.enter="getPagingSalary" placeholder="Nhập tháng " />
          <div class="icon-filter icon"></div>
        </div>

      </div>
      <div class="button-function">


        <button class="btn-excel">
          <a class="icon icon-excell"
            :href="`https://localhost:44301/api/luong/ExportExcel?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&nam=${this.year}&thang=${this.month}&pageNumber=${this.pageNumber}`"
            download>
            <div class="tooltip-excel">Xuất ra file excel</div>
          </a>
        </button>

      </div>
    </div>
    <div id="m-table" class="m-table">
      <table id="tbEmployee" class="table">
        <thead>
          <tr>

            <th class="text-center" style="min-width: 40px;">STT</th>
            <th>Mã nhân viên</th>
            <th>Họ và tên</th>
            <th>Ngày sinh</th>

            <th>Khoa</th>
            <th>Chức Vụ</th>
            <th>Hệ số lương</th>
            <th>Giá trị phụ cấp</th>
            <th>Phần trăm hưởng lương</th>
            <th>Tháng nhận</th>
            <th>Năm nhận</th>

            <th class="th-item-final sticky-right-top" colspan="12" style="min-width: 100px; text-align: center">
              <div class="th-item">
                <span class="table-text">Chức năng </span>
              </div>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr ref="row" v-for="(item, index) of salary" :key="item.IDLuong">

            <td class="text-center">{{ index + 1 }}</td>
            <td>{{ item.MaNV }}</td>
            <td>{{ item.TenNV }}</td>
            <td>{{ formatDate(item.NgaySinh) }}</td>

            <td>{{ item.TenKhoa }}</td>
            <td>{{ item.TenCVHT }}</td>
            <td>{{ item.HeSoLuong }}</td>

            <td>{{ item.GiaTriPhuCap }}</td>

            <td>{{ item.PhanTramHuongLuong }}</td>
            <td>{{ item.Thang }}</td>
            <td>{{ item.Nam }}</td>


            <td ref="func" class="td-item-final td-func sticky-right; align-items: center;"
              style="position: sticky; right: 0; background-color: #fff" colspan="12">
              <div style="width: 121px; box-sizing: border-box; margin-top: 5px;" class="desc text-center"
                @click="showDetail(item)">
                Xem chi tiết
              </div>
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
              <div class="item-dropup" :class="{ act: isActive == '10' }" pageSize="10" @click="getPageDefault">
                10 bản ghi trên 1 trang
              </div>
              <div class="item-dropup" :class="{ act: isActive == '20' }" pageSize="20" @click="getPageDefault">
                20 bản ghi trên 1 trang
              </div>
              <div class="item-dropup" :class="{ act: isActive == '30' }" pageSize="30" @click="getPageDefault"
                :value="pageDefault">
                30 bản ghi trên 1 trang
              </div>
              <div class="item-dropup" :class="{ act: isActive == '50' }" pageSize="50" @click="getPageDefault">
                50 bản ghi trên 1 trang
              </div>
              <div class="item-dropup" :class="{ act: isActive == '100' }" pageSize="100" @click="getPageDefault">
                100 bản ghi trên 1 trang
              </div>
            </div>
          </div>
        </div>
        <div>
          <Paginate v-model="page" :page-count="totalPage" :page-range="2" :margin-pages="1"
            :click-handler="clickCallback" :prev-link-class="'page-link'" :prev-text="'Trước'" :prev-class="'page-item'"
            :next-link-class="'page-link'" :next-text="'Sau'" :next-class="'page-item'" :container-class="'pagination'"
            :page-class="'page-item'">
          </Paginate>
        </div>
      </div>
    </div>
  </div>
  <FormDetail @load="getSalary" v-if="isShowFormDetail" :idNV="IDNV" :ngaySinh="NgaySinh" :maNV="MaNV" :tenNV="TenNV"
    :khoa="Khoa" :salarySL="salarySelected" @hideForm="hideFormDetail"></FormDetail>
  <popUp v-show="isShowPopup" @cancelNotifi="hideNotifi" :msv="empCodeDelete" @closeNotifi="deleteEmp"></popUp>
  <div id="load" v-show="isShowLoad">
    <div class="lds-ring">
      <div></div>
      <div></div>
      <div></div>
      <div></div>
    </div>
  </div>
  <!-- <div id="load" ></div> -->
</template>

<script>
import Paginate from "vuejs-paginate-next";
import axios from "axios";

import $ from "jquery";
// import Combobox from "../base/BaseCombobox2.vue";
import popUp from "../base/BasePopupDelete.vue"
// import { useToast } from "vue-toastification";
import FormDetail from '../base/SalaryDetail.vue'
export default {
  components: {
    Paginate, popUp, FormDetail
  },
  data() {
    return {
      isShowFormDetail: false,
      isActive: "20",
      pageNumber: 1,
      page: 1,
      salary: {},
      totalPage: 1,
      isShow: false,
      isShowDrop: false,
      totalRecord: 0,
      IDKhoa: "",
      pageDefault: 10,
      department: {},
      isShowLoad: false,
      departmentID: "",
      positionID: "",
      txtSearch: " ",
      year: "",
      month: "",
      salarySelected: [],
      newCode: "",
      formMode: 1,
      IDLuong: "",
      isShowPopup: false,
      empCodeDelete: "",
      empID: "",
      MaNV: "",
      TenNV: "",
      NgaySinh: "",
      Khoa: "",
      nhanvien: {},
      suanhanvien: {},
      tinhtrang: {},
      IDNV: "",
    };
  },
  created() {
    this.getPagingSalary()
    // this.getDepartment()
    // this.getPosition()
  },
  watch: {
    txtSearch: function () {
      if (this.txtSearch == "") {
        this.getPagingSalary();
      }
    },
    year: function () {
      if (this.year == "") {
        this.getPagingSalary();
      }
    },
    month: function () {
      if (this.month == "") {
        this.getPagingSalary();
      }
    },
  },
  methods: {
    getSalary() {
      this.getPagingSalary()
    },
    showDetail(item) {
      console.log(item);
      this.isShowFormDetail = !this.isShowFormDetail
      this.IDNV = item.IDNhanVien
      this.TenNV = item.TenNV
      this.MaNV = item.MaNV
      this.NgaySinh = item.NgaySinh
      this.Khoa = item.TenKhoa
      console.log(item.IDNhanVien);

    },

    getPagingSalary() {
      try {
        var me = this;
        me.isShowLoad = true

        axios
          .get(
            `https://localhost:44301/api/luong/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&nam=${this.year}&thang=${this.month}&pageNumber=${this.pageNumber}`

          )
          .then(function (res) {
            console.log(res);
            me.totalPage = res.data.TotalPages;
            me.totalRecord = res.data.TotalRecords;
            me.salary = res.data.Data;
            console.log(me.totalPage);

            me.isShowLoad = false

          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    hideFormDetail(value) {
      this.isShowFormDetail = value
    },
    // getPosition(){
    //   try {

    //    var me = this;

    //    axios
    //      .get(
    //       "https://localhost:44301/api/Position"
    //      )
    //      .then(function (res) {
    //       me.position=res.data
    //      })

    //      .catch(function () {
    //        console.log(1);
    //      });
    //  } catch (error) {
    //    console.log(error);
    //  }

    // },
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


    gender(gender) {
      switch (gender) {
        case 0:
          gender = "Nam"
          break;
        case 1:
          gender = "Nữ"
          break;
        default:
          break;
      }
      return gender;
    },
    showPage(is) {
      this.isShowDrop = is;
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
    getPageDefault(e) {
      this.isActive = e.target.getAttribute("pageSize");
      this.pageDefault = e.target.getAttribute("pageSize");
      this.showPage(false);
      $(".icon-dropup").removeClass("iconrotate");
      this.getPagingSalary()
      if (this.pageDefault > this.totalRecord) {
        this.pageDefault = this.totalRecord;
      }
    },
    clickCallback(pageNum) {
      this.pageNumber = pageNum;
      this.getPagingSalary()
    },
  },
};
</script>
<style scoped>
@import url('../../css/page/loading.css');



.btn-add:hover {
  opacity: 0.8;
}

.border-red {
  border: 1px solid red;
}

table {

  margin-top: 0px;
}

.desc {
  color: red;
  cursor: pointer;
  font-weight: 600;
}

.desc:hover {
  text-decoration: underline;
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
  z-index: 2;
  cursor: pointer;
}

.bonus-form {
  left: 50%;
  transform: translate(-50%, -5%);
  padding: 0px 20px;
  position: absolute;
  width: 55vw;
  height: 550px;
  /* height: auto; */
  margin: 0 auto;
  top: 15%;
  right: 15%;
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
  /* width: 96%; */
}

svg:hover {
  color: red;
}

.btn-close-popup::hover {
  color: red !important;
}

.form {
  background-color: rgba(0, 0, 0, 0.2);
  z-index: 3;
  width: 100%;
  height: 100%;
  margin: auto;
  position: fixed;
  display: flex;
  /* display: none; */
}

.formm input {
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
  margin-bottom: 7px;
}

.form {
  flex-direction: column;
  width: fit-content;
  height: fit-content;
  background-color: #fff;
  margin: auto auto;
  border-radius: 8px;
  width: 800px;
  margin-top: 100px;
  margin-left: 370px;
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

.column {
  margin-bottom: 12px;
}

.column input {
  /* width: 80%; */
}

.input__box {
  display: flex;
  justify-content: space-between;
  width: 100%;
  margin-bottom: 10px;
}

.form-bottom {
  display: flex;
  justify-content: flex-end;
  padding: 8px;
  gap: 28px;
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

.education-header {
  margin-bottom: 20px;
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
  border: 1px solid #7EA1F9;
}

.btnAdd:hover,
.btnEdit:hover {
  border: 1px solid #7EA1F9;
  background-color: #fff;
  color: #000;
}

.btnCancel,
.btnSave {
  width: 85px;
  border: 1px solid;
  text-align: center;
  padding: 5px;
  border-radius: 5px;
  color: #fff;

}

.btnSave {
  background-color: #7EA1F9;
  position: absolute;
  right: 40px;
  bottom: 20px;
}

.btnCancel {
  color: #000;
  border: 1px solid #ccc;
  position: absolute;
  right: 150px;
  bottom: 20px;
}

.btnCancel:hover {
  background-color: red;
  color: #fff;
}

.btnSave:hover {
  border: 1px solid #7EA1F9;
  color: #000;
  background-color: #fff;
}

.input__box {
  display: block;
}

.input__boxx {
  display: block;
  width: 100%;
}

.input__state {
  margin-bottom: 14px;
  display: flex;
  justify-content: space-between;
  width: 100%;
}

.input__state input {
  width: 80%;
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
  transform: translate(-90%, -80%);
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
  height: 25px;
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