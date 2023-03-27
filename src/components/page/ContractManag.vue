<template>
  <!-- chuc vu -->
    <div class="body">
    <div class="popup-bonus" v-if="isOpenPopupPosition">
      <div class="bonus-form">
        <div class="head-popup">
          <h3 class="title-heading">Chức vụ</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupPosition = false">
            <div class="icon">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke-width="1.5"
                stroke="currentColor"
                class="w-6 h-6"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                />
              </svg>
            </div>
          </div>
        </div>
        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <div class="btnAdd" @click="OpenPopupFormAddPosition(item)">Thêm</div>
            <!-- <div class="btnEdit" @click="OpenPopupFormEditPosition(item)">Sửa</div> -->
          </div>
        </div>
        <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
            <tr>
              <th>Tên chức vụ</th>
              <th>ĐỊnh mức giảng dạy</th>
              <th>Ngày bắt đầu</th>
              <th>Ngày kết thúc</th>
              <th style="width: 100px;">Chức năng</th>
            </tr>
            <tr>
            </tr>
            <tr>
              <td style="border: 1px solid #c7c7c7; width: 150px;">Giỏi</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">Giỏi</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">Giỏi</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">Giỏi</td>
              <td 
              ref="func"
              class="td-item-final td-func"
              style="background-color: #fff; align-items: center; border: 1px solid #c7c7c7; column-gap: 10px;"
              colspan="12"
              >
                <div class="icon icon-edit" @click="OpenPopupFormEditPosition(item)"></div>
                <div class="icon icon-delete" @click="OpenPopupDeleteNotifi(item)"></div>
              </td>
            </tr>
          </table>
        <!-- <div class="btnDelete" style="bottom: -140px;">Xóa</div> -->
      </div>
    </div>
    <!-- them chuc vu -->
    <div class="popup-bonus" v-if="isOpenPopupFormAddPosition">
      <div class="bonus-form">
        <div class="head-popup">
          <h3 class="title-heading">Thêm chức vụ</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupAddNotifi = true">
            <div class="icon">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke-width="1.5"
                stroke="currentColor"
                class="w-6 h-6"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                />
              </svg>
            </div>
          </div>
        </div>
        
        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
            <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <div class="form">
          <form action="">
            <div class="column">
              <div class="input__box">
                <label for="">Mã chức vụ</label>
                <input type="text"/>
              </div>
              <div class="input__box">
                <label for="">Tên chức vụ</label>
                <input type="text"/>
              </div>
            </div>
            <div class="column">
              <div class="input__box">
                <label for="">Thời gian bắt đầu</label>
                <input type="text"/>
              </div>
              <div class="input__box">
                <label for="">Thời gian kết thúc</label>
                <input type="text"/>
              </div>
              <div class="input__box">
                <label for="">Định mức giảng dạy</label>
                <input type="text"/>
              </div>
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupAddNotifi = true">Hủy</div>
        <div class="btnSave">Lưu</div>
      </div>
    </div>
    <!-- sua chuc vu-->
    <div class="popup-bonus" v-if="isOpenPopupFormEditPosition">
      <div class="bonus-form">
        <div class="head-popup">
          <h3 class="title-heading">Sửa chức vụ</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupEditNotifi = true">
            <div class="icon">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke-width="1.5"
                stroke="currentColor"
                class="w-6 h-6"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                />
              </svg>
            </div>
          </div>
        </div>
        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
            <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <div class="form">
          <form action="">
            <div class="column">
              <div class="input__box">
                <label for="">Mã chức vụ</label>
                <input type="text"/>
              </div>
              <div class="input__box">
                <label for="">Tên chức vụ</label>
                <input type="text"/>
              </div>
            </div>
            <div class="column">
              <div class="input__box">
                <label for="">Thời gian bắt đầu</label>
                <input type="text"/>
              </div>
              <div class="input__box">
                <label for="">Thời gian kết thúc</label>
                <input type="text"/>
              </div>
              <div class="input__box">
                <label for="">Định mức giảng dạy</label>
                <input type="text"/>
              </div>
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupEditNotifi = true">Hủy</div>
        <div class="btnSave">Lưu</div>
      </div>
    </div>
    <!-- end open popup chuc vu   -->
    <!-- cảnh báo thêm chức vụ -->
    <div class="notification-wrap" v-if="isOpenPopupAddNotifi">
    <div class="notification">
        <div class="warring">
            <i class="icon-warning"></i>
            <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
        </div>
        <div class="btn-wrap">
            <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupAddNotifi = false, isOpenPopupFormAddPosition=false)" >Hủy</div>
            <div class="btnNotifi btn-primary" @click="isOpenPopupAddNotifi = false">Không</div>
        </div>
    </div>
    </div>
    <!-- cảnh báo sửa chức vụ-->
    <div class="notification-wrap" v-if="isOpenPopupEditNotifi">
      <div class="notification">
          <div class="warring">
              <i class="icon-warning"></i>
              <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
          </div>
          <div class="btn-wrap">
              <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupEditNotifi = false, isOpenPopupFormEditPosition=false)" >Hủy</div>
              <div class="btnNotifi btn-primary" @click="isOpenPopupEditNotifi = false">Không</div>
          </div>
      </div>
    </div>
     <!-- cảnh báo xóa chức vụ-->
     <div class="notification-wrap" v-if="isOpenPopupDeleteNotifi">
      <div class="notification">
          <div class="warring">
              <i class="icon-warning"></i>
              <div class="warrning-title">Thông tin chức vụ của sinh viên. Bạn có muốn xóa thông tin không?</div>
          </div>
          <div class="btn-wrap">
              <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupDeleteNotifi = false, isOpenPopupFormEditContract=false)" >Hủy</div>
              <div class="btnNotifi btn-primary" @click="isOpenPopupDeleteNotifi = false">Không</div>
          </div>
      </div>
    </div>

    <!-- cảnh báo thêm hợp đồng -->
    <div class="notification-wrap" v-if="isOpenPopupAddNotifiCV">
    <div class="notification">
        <div class="warring">
            <i class="icon-warning"></i>
            <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
        </div>
        <div class="btn-wrap">
            <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupAddNotifiCV = false, isOpenPopupFormAddContract=false)" >Hủy</div>
            <div class="btnNotifi btn-primary" @click="isOpenPopupAddNotifiCV = false">Không</div>
        </div>
    </div>
    </div>
    <!-- cảnh báo xóa hợp đồng-->
    <div class="notification-wrap" v-if="isOpenPopupDeleteNotifiCV">
      <div class="notification">
          <div class="warring">
              <i class="icon-warning"></i>
              <div class="warrning-title">Thông tin hợp đồng của sinh viên. Bạn có muốn xóa thông tin không?</div>
          </div>
          <div class="btn-wrap">
              <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupDeleteNotifiCV = false, isOpenPopupFormEditContract=false)" >Hủy</div>
              <div class="btnNotifi btn-primary" @click="isOpenPopupDeleteNotifiCV = false">Không</div>
          </div>
      </div>
    </div>
    <!-- cảnh báo sửa hợp đồng-->
    <div class="notification-wrap" v-if="isOpenPopupEditNotifiCV">
      <div class="notification">
          <div class="warring">
              <i class="icon-warning"></i>
              <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
          </div>
          <div class="btn-wrap">
              <div class="btnNotifi btn-secondary" @click.stop="(isOpenPopupEditNotifiCV = false, isOpenPopupFormEditContract=false)" >Hủy</div>
              <div class="btnNotifi btn-primary" @click="isOpenPopupEditNotifiCV = false">Không</div>
          </div>
      </div>
    </div>

      <!-- hop dong -->
      <div class="popup-bonus" v-if="isOpenPopupContract">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Thông tin hợp đồng</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupContract = false">
              <div class="icon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="1.5"
                  stroke="currentColor"
                  class="w-6 h-6"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                  />
                </svg>
              </div>
            </div>
          </div>
          <div class="education-header">
            <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
            <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
            <div class="btnWrap">
              <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
              <!-- <div class="btnEdit" @click="OpenPopupFormEditContract(item)">Sửa</div> -->
            </div>
          </div>
          <div class="form">
            <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
            <tr>
              <th>Mã hợp đồng</th>
              <th>Tên hợp đồng</th>
              <th>Ngày ký</th>
              <th>Ngày bắt đầu</th>
              <th>Ngày kết thúc</th>
              <th>Mô tả</th>
              <th style="width: 100px;">Chức năng</th>
            </tr>
            <tr>
            </tr>
            <tr>
              <td style="border: 1px solid #c7c7c7; width: 150px;">Giỏi</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">Giỏi</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">Giỏi</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">Giỏi</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">Giỏi</td>
              <td style="border: 1px solid #c7c7c7; width: 150px;">Giỏi</td>
              <td 
              ref="func"
              class="td-item-final td-func"
              style="background-color: #fff; align-items: center; border: 1px solid #c7c7c7; column-gap: 10px;"
              colspan="12"
              >
                <div class="icon icon-edit" @click="OpenPopupFormEditContract(item)"></div>
                <div class="icon icon-delete" @click="OpenPopupDeleteNotifiCV(item)"></div>
              </td>
            </tr>
          </table>
            <!-- <div class="btnDelete" style="bottom: -16px">Xóa</div> -->
          </div>
          
        </div>
      </div>
      <!-- them hop dong -->
      <div class="popup-bonus" v-if="isOpenPopupFormAddContract">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Thêm hợp đồng</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupAddNotifiCV = true">
              <div class="icon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="1.5"
                  stroke="currentColor"
                  class="w-6 h-6"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                  />
                </svg>
              </div>
            </div>
          </div>
          <div class="education-header">
            <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
            <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
            <div class="btnWrap">
              <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
              <div class="btnEdit">Sửa</div> -->
            </div>
          </div>
          <div class="form">
            <form action="">
              <div class="column">
                <div class="input__box">
                  <label for="">Mã hợp đồng</label>
                  <input type="text"/>
                </div>
                <div class="input__box">
                  <label for="">Tên hợp đồng</label>
                  <input type="text"/>
                </div>
              </div>
              <div class="column">
                <div class="input__box">
                  <label for="">Ngày kí</label>
                  <input type="text"/>
                </div>
                <div class="input__box">
                  <label for="">Ngày bắt đầu</label>
                  <input type="text"/>
                </div>
                <div class="input__box">
                  <label for="">Ngày kết thúc</label>
                  <input type="text"/>
                </div>
              </div>
              <div class="column">
                <div class="input__box">
                  <label for="">Mô tả</label>
                  <textarea style="width: 97%;height: 60px;margin-top: 5px;"></textarea>
                </div>
              </div>
            </form>
          </div>
          <div class="btnCancel" @click.stop="isOpenPopupAddNotifiCV = true">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
      </div>
      <!-- sua hop dong-->
      <div class="popup-bonus" v-if="isOpenPopupFormEditContract">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Sửa hợp đồng</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupEditNotifiCV = true">
              <div class="icon">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="1.5"
                  stroke="currentColor"
                  class="w-6 h-6"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                  />
                </svg>
              </div>
            </div>
          </div>
          <div class="education-header">
            <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
            <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
            <div class="btnWrap">
              <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
              <div class="btnEdit">Sửa</div> -->
            </div>
          </div>
          <div class="form">
            <form action="">
              <div class="column">
                <div class="input__box">
                  <label for="">Mã hợp đồng</label>
                  <input type="text"/>
                </div>
                <div class="input__box">
                  <label for="">Tên hợp đồng</label>
                  <input type="text"/>
                </div>
              </div>
              <div class="column">
                <div class="input__box">
                  <label for="">Ngày kí</label>
                  <input type="text"/>
                </div>
                <div class="input__box">
                  <label for="">Ngày bắt đầu</label>
                  <input type="text"/>
                </div>
                <div class="input__box">
                  <label for="">Ngày kết thúc</label>
                  <input type="text"/>
                </div>
              </div>
              <div class="column">
                <div class="input__box">
                  <label for="">Mô tả</label>
                  <textarea style="width: 97%;height: 60px;margin-top: 5px;"></textarea>
                </div>
              </div>
            </form>
          </div>
          <div class="btnCancel" @click.stop="isOpenPopupEditNotifiCV = true">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
      </div>
      <!-- end hop dong -->

      <h3 class="header-bd">Quản lý hợp đồng</h3>
      <div class="body-header">
        <div class="row-input">
          <div class="input">
            <input type="text" class="search" placeholder="Tìm kiếm"  v-model="txtSearch"  @keypress.enter="getPagingEmployee"  />
            <div class="icon-search icon"></div>
          </div>
        </div>
      </div>
      <!-- table -->
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
              <th class="text-center" style="min-width: 40px">STT</th>
              <th>Mã nhân viên </th>
              <th>Họ và tên</th>
              <th>Ngày sinh</th>
              <th>Giới tính</th>
              <th>Gmail</th>
              <th>Chức vụ</th>
              <th>Hợp đồng</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item,i) of students" :key="item.StudentID" ref="row">
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
              <td class="text-center">{{ i+1 }}</td>
              <td>{{ item.MaNV }}</td>
              <td>{{ item.TenNV }}</td>
              <td>{{ item.NgaySinh }}</td>
              <td>{{ item.GioiTinh }}</td>
              <td>{{ item.Email }}</td>
              <td>
                <div class="desc"  @click="OpenPopupPosition(item)">
                  Xem chi tiết
                </div>
              </td>
              <td>
                <div class="desc" @click="OpenPopupContract(item)">
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
                <div
                  class="item-dropup"
                  :class="{ act: isActive == '10' }"
                  pageSize="10"
                  :value="pageDefault"
                  @click="getPageDefault"
                >
                  10 bản ghi trên 1 trang
                </div>
                <div
                  class="item-dropup"
                  :class="{ act: isActive == '20' }"
                  pageSize="20"
                  @click="getPageDefault"
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
              v-model="pageNumber"
              :page-count="totalPage"
              :page-range="3"
              :margin-pages="1"
              :click-handler="clickCallback"
              :prev-text="'Trước'"
              :next-text="'Sau'"
              :container-class="'pagination'"
              :page-class="'page-item'"
            >
            </Paginate>
          </div>
        </div>
      </div>
    </div>
    <Form v-show="isShow" @hideForm="closeForm"></Form>
  </template>
  <script>
  import axios from "axios"
  import $ from "jquery"
  import Paginate from "vuejs-paginate-next";
  import { useToast } from "vue-toastification";
  export default {
    data() {
      return {
        isOpenPopupContract: false,
        isOpenPopupFostering: false,
        isOpenPopupPosition: false,
        isOpenPopupFormAddPosition: false,
        isOpenPopupFormEditPosition: false,
        isOpenPopupFormAddContract: false,
        isOpenPopupFormEditContract: false,
        isOpenPopupEditNotifi: false,
        isOpenPopupAddNotifi: false,
        isOpenPopupAddNotifiCV: false,
        isOpenPopupEditNotifiCV: false,
        isOpenPopupDeleteNotifiCV: false,
        isOpenPopupDeleteNotifi: false,
        pageDefault:10,
        pageNumber: 1,
        txtSearch:"",
        totalPage:1,
        totalRecord:0,
        students:{},
        isShowDrop:false,
        dataSinhVienPunish:[],
        dataSinhVienBonus:{}

      };
    },
    components: {
      Paginate
    },
    watch: {
    txtSearch: function () {
      if (this.txtSearch == "") {
        this.getpagingStudent();
      }
    },
  },
  created(){
    this.getpagingStudent()
   
  },
    methods: {
      SavePunish(){
        var me= this
        const toast = useToast();
        try {
        
          axios
            .post(
              "https://localhost:44301/api/Discipline",this.dataSinhVienPunish
            )
            .then(function (res) {
              console.log(res)
              toast.success("thêm dữ liệu thành công", { timeout: 2000 });
              me.isOpenPopupPosition=false
            })
            .catch(function () {
              console.log("error");
              toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
            });
          } catch (error) {
            console.log(error);
          }
      },
      SaveBonus(){
        var me= this
        const toast = useToast();
        try {
          axios
            .post(
              "https://localhost:44301/api/Bonus",
              
                this.dataSinhVienBonus
              
            )
            .then(function (res) {
              console.log(res)
              toast.success("thêm dữ liệu thành công", { timeout: 2000 });
              me.isOpenPopupContract()
            })
            .catch(function () {
              console.log("error");
              toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
            });
          } catch (error) {
            console.log(error);
          }
      },
      thongbao() {
        alert("Xác nhận đóng");
      },
      OpenPopupContract(item) {
        this.isOpenPopupContract = true;
        this.dataSinhVienBonus = item
        this.MaNV = item.MaNV
        this.TenNV = item.TenNV
      },
      OpenPopupFostering(item) {
        this.isOpenPopupFostering = true;
        this.dataSinhVienBonus = item
        this.MaNV = item.MaNV
        this.TenNV = item.TenNV
      },
      OpenPopupPosition(item) {
        this.isOpenPopupPosition = true;
        this.dataSinhVienPunish = item
        this.MaNV = item.MaNV
        this.TenNV = item.TenNV
      },
      OpenPopupFormAddPosition(item) {
        this.isOpenPopupFormAddPosition = true;
        this.dataSinhVienPunish = item
      },
      OpenPopupFormEditPosition(item) {
        this.isOpenPopupFormEditPosition = true;
        this.dataSinhVienPunish = item
      },
      OpenPopupFormAddContract(item) {
        this.isOpenPopupFormAddContract = true;
        this.dataSinhVienPunish = item
      },
      OpenPopupFormEditContract(item) {
        this.isOpenPopupFormEditContract = true;
        this.dataSinhVienPunish = item
      },
      OpenPopupFormAddFostering(item) {
        this.isOpenPopupFormAddFostering = true;
        this.dataSinhVienPunish = item
      },
      OpenPopupFormEditFostering(item) {
        this.isOpenPopupFormEditFostering = true;
        this.dataSinhVienPunish = item
      },
      OpenPopupAddNotifi(item) {
      this.isOpenPopupAddNotifi = true;
      this.dataSinhVienPunish = item
    },
    OpenPopupEditNotifi(item) {
      this.isOpenPopupEditNotifi = true;
      this.dataSinhVienPunish = item
    },
    OpenPopupAddNotifiCV(item) {
      this.isOpenPopupAddNotifiCV = true;
      this.dataSinhVienPunish = item
    },
    OpenPopupEditNotifiCV(item) {
      this.isOpenPopupEditNotifiCV = true;
      this.dataSinhVienPunish = item
    },
    OpenPopupDeleteNotifiCV(item) {
      this.isOpenPopupDeleteNotifiCV = true;
      this.dataSinhVienPunish = item
    },
    OpenPopupDeleteNotifi(item) {
      this.isOpenPopupDeleteNotifi = true;
      this.dataSinhVienPunish = item
    },
    //   getPagingEmployee() {
    //   try {
       
    //     var me = this;
    //    me.isShowLoad=true
    //     axios
    //       .get(
    //         `https://localhost:44301/api/nhanvien/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&IDKhoa=${this.IDKhoa}&pageNumber=${this.pageNumber}`
           
    //       )
    //       .then(function (res) {
    //       console.log(res);
    //         me.totalPage = res.data.TotalPages;
    //         me.totalRecord = res.data.TotalRecords;
    //         me.employees = res.data.Data;
    //         console.log( me.totalPage);
    //         console.log(me.employees);
    //         me.isShowLoad=false
            
    //       })
         
    //       .catch(function () {
    //         console.log(1);
    //       });
    //   } catch (error) {
    //     console.log(error);
    //   }
    // },
      getpagingStudent() {
      try {
       
        var me = this;
       
        axios
          .get(
            `https://localhost:44301/api/nhanvien/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&IDKhoa=${this.IDKhoa}&pageNumber=${this.pageNumber}`
          )
          .then(function (res) {
          
            me.totalPage = res.data.TotalPages;
            me.totalRecord = res.data.TotalRecords;
            me.students = res.data.Data;
            
           
            
          })
         
          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
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
      this.getpagingStudent();
      if (this.pageDefault > this.totalRecord) {
        this.pageDefault = this.totalRecord;
      }
    },

    clickCallback(pageNum) {
      this.pageNumber = pageNum;
      this.getpagingStudent();
    },
    },
  };
  </script>
  <style scoped>
  .btnSave {
    background-color: #7EA1F9;
    position: absolute;
    right: 40px;
    bottom: 10px;
  }
  .btnCancel {
    color: #000;
    border: 1px solid #ccc;
    position: absolute;
    right: 150px;
    bottom: 10px;
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
  .column input {
    width: 80%;
  }
  .input__box {
    display: block;
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
    margin: 20px 0;
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
  
  .btnDelete {
    padding: 3px 25px;
    border-radius: 5px;
    color: #fff;
    background-color: red;
    right: 40px;
    position: absolute;
    bottom: 15px;
  }
  .btnDelete:hover {
    border: 1px solid red;
    background-color: #fff;
    color: #000;
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
    width: 200px ;
}
.content-page {
    min-width: 170px;
    margin-left: 6px;
    margin-right: 10px;
    margin-top: 9px;
    position: relative;
}
.page-link{
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
.page{
  margin-top: 10px;
  margin-right: 20px;
}
 
  table{
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
  .btn-action:hover{
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
    z-index: 2;
    cursor: pointer;
  }
  .bonus-form {
    padding: 0px 20px;
    position: absolute;
    width: 50vw;
    height: 490px;
    /* height: auto; */
    margin: 0 auto;
    top: 15%;
    right: 15%;
    z-index: 99999;
    border-radius: 20px;
    box-shadow: 5px 5px 5px ;
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
  input{
    width: 300px;
  }
  table[data-v-07d000ee], tr[data-v-07d000ee], td[data-v-07d000ee] {
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
thead tr{
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
tbody tr:hover .checkbox, tbody tr:hover .td-item-final{
  background-color: #fff !important;
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

.form input {
  width: 90%;
  margin-top: 5px;
  margin-bottom: 10px;
}
.form {
  width: fit-content;
  height: fit-content;
  background-color: #fff;
  margin: auto auto;
  border-radius: 8px;
}
  </style>
  