<template>
  <div class="body">
    <div class="popup-bonus" v-if="isOpenPopupPosition">
      <div class="bonus-form">
        <div class="head-popup">
          <h3 class="title-heading">Thông tin khen thưởng</h3>
          <div
            class="btn-close-popup"
            @click.stop="isOpenPopupPosition = false"
          >
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
          <div class="tenNV">Tên nhân viên: {{ currentNameNhanVien }}</div>
          <div class="btnWrap">
            <div
              class="btnAdd"
              @click="OpenPopupFormAddPosition(dataInfoBonus)"
            >
              Thêm
            </div>
            <!-- <div class="btnEdit" @click="OpenPopupFormEditPosition(item)">Sửa</div> -->
          </div>
        </div>
        <table
          style="
            width: 100%;
            border-collapse: collapse;
            border: 1px solid;
            margin-top: 12px;
          "
        >
          <tr>
            <th>Hình thức khen thưởng</th>
            <th>Ngày khen thưởng</th>
            <th>Lý do</th>
            <th style="width: 100px">Chức năng</th>
          </tr>
          <tr></tr>
          <tr v-for="item of dataInfoBonus" :key="item.IDChucVu">
            <td style="border: 1px solid #c7c7c7; width: 150px">
              {{ item.HinhThucKT }}
            </td>
            <td style="border: 1px solid #c7c7c7; width: 150px">
              {{ formatDate(item.NgayKT) }}
            </td>
            <td style="border: 1px solid #c7c7c7; width: 150px">
              {{ item.LyDoKT }}
            </td>
            <td
              ref="func"
              class="td-item-final td-func"
              style="
                background-color: #fff;
                align-items: center;
                border: 1px solid #c7c7c7;
                column-gap: 10px;
              "
              colspan="12"
            >
              <div
                class="icon icon-edit"
                @click="OpenPopupFormEditPosition(item)"
              ></div>
              <div
                class="icon icon-delete"
                @click="OpenPopupDeleteNotifi(item)"
              ></div>
            </td>
          </tr>
        </table>
      </div>
    </div>
    <popUp
      v-show="isShowPopupPosition"
      :msv="mess"
      @cancelNotifi="noDelete"
      @closeNotifi="deletePosition"
    ></popUp>

    <!-- them chuc vu -->
    <div class="popup-bonus" v-if="isOpenPopupFormAddPosition">
      <div class="bonus-formm">
        <div class="head-popup">
          <h3 class="title-heading">Thêm thông tin khen thưởng</h3>
          <div
            class="btn-close-popup"
            @click.stop="isOpenPopupAddNotifi = true"
          >
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
          <div class="tenNV">Tên nhân viên: {{ currentNameNhanVien }}</div>
          <div class="btnWrap"></div>
        </div>
        <div class="form">
          <form action="">
            <div class="input__box">
              <label for="">Hình thức khen thưởng</label>
              <input
                :class="errors.tenchucvu != '' ? 'border-red' : ''"
                @blur="validateName"
                type="text"
                v-model="dataAddInfoBonus.HinhThucKT"
              />
              <div class="invalid-feedback" v-if="errors.tenchucvu != ''">
                {{ errors.tenchucvu }}
              </div>
            </div>
            <div class="input__box">
              <label for="">Chọn ngày khen thưởng</label>
              <input type="date" v-model="dataAddInfoBonus.NgayKT" />
            </div>

            <div class="input__box">
              <label for="">Thêm lý do khen thưởng</label>
              <input
                :class="errors.dinhmucgiangday != '' ? 'border-red' : ''"
                @blur="validateNorm"
                type="text"
                v-model="dataAddInfoBonus.LyDoKT"
              />
              <div class="invalid-feedback" v-if="errors.dinhmucgiangday != ''">
                {{ errors.dinhmucgiangday }}
              </div>
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupAddNotifi = true">
          Hủy
        </div>
        <div class="btnSave" @click="AddDataInfoBonus(dataAddInfoBonus)">
          Lưu
        </div>
      </div>
    </div>
    <!-- sua chuc vu-->
    <div class="popup-bonus" v-if="isOpenPopupFormEditPosition">
      <div class="bonus-formm">
        <div class="head-popup">
          <h3 class="title-heading">Sửa thông tin khen thưởng</h3>
          <div
            class="btn-close-popup"
            @click.stop="isOpenPopupEditNotifi = true"
          >
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
          <div class="tenNV">Tên nhân viên: {{ currentNameNhanVien }}</div>
          <div class="btnWrap"></div>
        </div>
        <div class="form">
          <form action="">
            <div class="input__box">
              <label for="">Hình thức khen thưởng</label>
              <input type="text" v-model="dataEditInfoBonus.HinhThucKT" />
            </div>
            <div class="input__box">
              <label for="">Ngày khen thưởng</label>
              <input type="date" v-model="dataEditInfoBonus.NgayKT" />
            </div>

            <div class="input__box">
              <label for="">Lý do khen thưởng</label>
              <input type="text" v-model="dataEditInfoBonus.LyDoKT" />
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupEditNotifi = true">
          Hủy
        </div>
        <div class="btnSave" @click="btnEditPosition(dataEditInfoBonus)">
          Lưu
        </div>
      </div>
    </div>
    <!-- end open popup khen thưởng   -->
    <!-- cảnh báo thêm khen thưởng -->
    <div class="notification-wrap" v-if="isOpenPopupAddNotifi">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>

          <div class="warrning-title">
            Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?
          </div>
        </div>
        <div class="btn-wrap">
          <div
            class="btnNotifi btn-secondary"
            @click.stop="
              (isOpenPopupAddNotifi = false),
                (isOpenPopupFormAddPosition = false)
            "
          >
            Hủy
          </div>
          <div
            class="btnNotifi btn-primary"
            @click="isOpenPopupAddNotifi = false"
          >
            Không
          </div>
        </div>
      </div>
    </div>
    <!-- cảnh báo sửa khen thưởng -->
    <div class="notification-wrap" v-if="isOpenPopupEditNotifi">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>
          <div class="warrning-title">
            Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?
          </div>
        </div>
        <div class="btn-wrap">
          <div
            class="btnNotifi btn-secondary"
            @click.stop="
              (isOpenPopupEditNotifi = false),
                (isOpenPopupFormEditPosition = false)
            "
          >
            Hủy
          </div>
          <div
            class="btnNotifi btn-primary"
            @click="isOpenPopupEditNotifi = false"
          >
            Không
          </div>
        </div>
      </div>
    </div>

    <div class="popup-bonus" v-if="isOpenPopupContract">
      <div class="bonus-form">
        <div class="head-popup">
          <h3 class="title-heading">Thông tin Kỷ Luật</h3>
          <div
            class="btn-close-popup"
            @click.stop="isOpenPopupContract = false"
          >
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
          <div class="tenNV">Tên nhân viên: {{ currentNameNhanVien }}</div>
          <div class="btnWrap">
            <div class="btnAdd" @click="OpenPopupFormAddContract(item)">
              Thêm
            </div>
          </div>
        </div>
        <div class="formm">
          <table
            style="
              width: 100%;
              border-collapse: collapse;
              border: 1px solid;
              margin-top: 12px;
            "
          >
            <tr>
              <th>Hình thức kỷ luật </th>
              <th>Ngày kỷ luật</th>
              <th>Lý do</th>
              <th style="width: 100px">Chức năng</th>
            </tr>
            <tr></tr>

            <tr v-for="item of dataListKiLuat" :key="item.NgayKL">
              <td style="border: 1px solid #c7c7c7; width: 150px">
                {{ item.HinhThucKL }}
              </td>
              <td style="border: 1px solid #c7c7c7; width: 150px">
                {{ formatDate(item.NgayKL) }}
              </td>
              <td style="border: 1px solid #c7c7c7; width: 150px">
                {{ item.LyDoKL }}
              </td>
              <td
                ref="func"
                class="td-item-final td-func"
                style="
                  background-color: #fff;
                  align-items: center;
                  border: 1px solid #c7c7c7;
                  column-gap: 10px;
                "
                colspan="12"
              >
                <div
                  class="icon icon-edit"
                  @click="OpenPopupFormEditContract(item)"
                ></div>
                <div
                  class="icon icon-delete"
                  @click="OpenPopupDeleteNotifiCV(item)"
                ></div>
              </td>
            </tr>
          </table>
        </div>
      </div>
    </div>
    <popUp
      v-show="isShowPopupContract"
      :msv="mess"
      @cancelNotifi="noDelete"
      @closeNotifi="deleteNotifiContract"
    ></popUp>

    <!-- Thêm thông tin kỷ luật -->
    <div class="popup-bonus" v-if="isOpenPopupFormAddContract">
      <div class="bonus-formm">
        <div class="head-popup">
          <h3 class="title-heading">Thêm thông tin kỷ luật</h3>
          <div
            class="btn-close-popup"
            @click.stop="isOpenPopupAddNotifiCV = true"
          >
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
          <div class="maNV">Mã nhân viên: {{ this.MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ this.currentNameNhanVien }}</div>
          <div class="btnWrap"></div>
        </div>
        <div class="form">
          <form action="">
            <div class="column">
              <div class="input__box">
                <label for="">Hình thức kỷ luật </label>
                <input
                  :class="errors.tenhopdong != '' ? 'border-red' : ''"
                  @blur="validateName"
                  type="text"
                  v-model="dataAddKyLuat.HinhThucKL"
                />
                <div class="invalid-feedback" v-if="errors.tenhopdong != ''">
                  {{ errors.tenhopdong }}
                </div>
              </div>
              <div class="input__box">
                <label for="">Ngày kỷ luật</label>
                <input
                  :class="errors.ngayki != '' ? 'border-red' : ''"
                  @blur="validateNgayKi"
                  type="date"
                  v-model="dataAddKyLuat.NgayKL"
                />
                <div class="invalid-feedback" v-if="errors.ngayki != ''">
                  {{ errors.ngayki }}
                </div>
              </div>
            </div>

            <div class="column">
              <div class="input__box">
                <label for="">Lý do</label>
                <textarea
                  v-model="dataAddKyLuat.LyDoKL"
                  style="width: 95%; height: 60px; margin-top: 5px"
                ></textarea>
              </div>
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupAddNotifiCV = true">
          Hủy
        </div>
        <div class="btnSave" @click="saveDataKyLuat(dataAddKyLuat)">Lưu</div>
      </div>
    </div>
    <!-- Sửa thông tin kỷ luật-->
    <div class="popup-bonus" v-if="isOpenPopupFormEditContract">
      <div class="bonus-formm">
        <div class="head-popup">
          <h3 class="title-heading">Sửa thông tin kỷ luật</h3>
          <div
            class="btn-close-popup"
            @click.stop="isOpenPopupEditNotifiCV = true"
          >
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
          <div class="btnWrap"></div>
        </div>
        <div class="form">
          <form action="">
            <div class="column" style="display: block">
              <div class="input__box">
                <label for="">Thêm hình thức kỷ luật </label>
                <input type="text" v-model="dataEditContract.HinhThucKL" />
              </div>
              <br />
              <div class="input__box">
                <label for="">Chọn ngày kỷ luật</label>
                <input type="date" v-model="dataEditContract.NgayKL" />
              </div>
            </div>
            <div class="column">
              <div class="input__box">
                <label for="">Thêm lý do kỷ luật</label>
                <textarea
                  v-model="dataEditContract.LyDoKL"
                  style="width: 95%; height: 60px; margin-top: 5px"
                ></textarea>
              </div>
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupEditNotifiCV = true">
          Hủy
        </div>
        <div class="btnSave" @click="btnEditContract(dataEditContract)">
          Lưu
        </div>
      </div>
    </div>
    <!-- end thêm thông tin kỷ luật -->
    <!-- cảnh báo thêm thông tin kỷ luật -->
    <div class="notification-wrap" v-if="isOpenPopupAddNotifiCV">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>
          <div class="warrning-title">
            Thông tin bạn vừa nhập chưa được lưu . Bạn có muốn hủy thông tin?
          </div>
        </div>
        <div class="btn-wrap">
          <div
            class="btnNotifi btn-secondary"
            @click.stop="
              (isOpenPopupAddNotifiCV = false),
                (isOpenPopupFormAddContract = false)
            "
          >
            Hủy
          </div>
          <div
            class="btnNotifi btn-primary"
            @click="isOpenPopupAddNotifiCV = false"
          >
            Không
          </div>
        </div>
      </div>
    </div>
    <!-- end thêm sửa tin kỷ luật -->
    <!-- cảnh báo sửa thông tin kỷ luật -->
    <div class="notification-wrap" v-if="isOpenPopupEditNotifiCV">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>
          <div class="warrning-title">
            Thông tin bạn vừa nhập chưa được lưu . Bạn có muốn hủy thông tin?
          </div>
        </div>
        <div class="btn-wrap">
          <div
            class="btnNotifi btn-secondary"
            @click.stop="
              (isOpenPopupEditNotifiCV = false),
                (isOpenPopupFormEditContract = false)
            "
          >
            Hủy
          </div>
          <div
            class="btnNotifi btn-primary"
            @click="isOpenPopupEditNotifiCV = false"
          >
            Không
          </div>
        </div>
      </div>
    </div>

    <h3 class="header-bd">Khen thưởng/Kỷ luật</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input
            type="text"
            class="search"
            placeholder="Tìm kiếm"
            v-model="txtSearch"
            @keypress.enter="getpagingStudent"
          />
          <div class="icon-search icon"></div>
        </div>
      </div>
    </div>
    <!-- table -->
    <div id="m-table" class="m-table">
      <table id="tbEmployee" class="table" style="width: 100%">
        <thead>
          <tr>
            <th class="text-center" style="min-width: 40px">STT</th>
            <th>Mã nhân viên</th>
            <th>Họ và tên</th>
            <th>Giới tính</th>
            <th>Email</th>
            <th>Khen thưởng</th>
            <th>Kỉ Luật</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, i) of students" :key="item.IDNhanVien" ref="row">
            <!-- <td ref="rowCheck" class="checkbox sticky-left" style="text-align: center" colspan="1">
              <input ref="check" class="check-item" type="checkbox" style="width: 18px; height: 18px" />
            </td> -->
            <td class="text-center">{{ i + 1 }}</td>
            <td>{{ item.MaNV }}</td>
            <td>{{ item.TenNV }}</td>
            <td>{{ gender(item.GioiTinh) }}</td>
            <td>{{ item.Email }}</td>
            <td>
              <div class="desc" @click="OpenPopupPosition(item)">
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
  <div id="load" v-show="isShowLoad">
    <div class="lds-ring">
      <div></div>
      <div></div>
      <div></div>
      <div></div>
    </div>
  </div>
</template>
<script>
import axios from "axios";
import $ from "jquery";
import Paginate from "vuejs-paginate-next";
import { useToast } from "vue-toastification";
import popUp from "../base/BasePopupDelete2.vue";
export default {
  data() {
    return {
      dataAddKyLuat: {},
      currentIdNhanVien: null,
      currentNameNhanVien: "",
      currentMaNhanVien: "",
      dataInfoBonus: {},
      dataAddInfoBonus: {},
      dataListKiLuat: {},
      dataEditContract: {},
      isOpenPopupContract: false,
      isOpenPopupFostering: false,
      isOpenPopupFormEditContract: false,
      isOpenPopupPosition: false,
      isOpenPopupFormAddPosition: false,
      isOpenPopupFormEditPosition: false,
      isOpenPopupFormAddContract: false,
      isOpenPopupEditNotifi: false,
      isOpenPopupAddNotifi: false,
      isOpenPopupAddNotifiCV: false,
      isOpenPopupEditNotifiCV: false,
      isOpenPopupDeleteNotifiCV: false,
      isOpenPopupDeleteNotifi: false,
      pageDefault: 10,
      pageNumber: 1,
      txtSearch: "",
      totalPage: 1,
      totalRecord: 0,
      students: {},
      isShowDrop: false,
      dataSinhVienPunish: [],
      dataSinhVienBonus: {},
      chucvu: {},
      hopdong: {},
      isShowLoad: false,
      IDNV: "",
      MaNV: "",
      TenNV: "",
      suaChucVu: {},
      suaHopDong: {},
      mess: "",
      idDelete: "",
      isShowPopupContract: false,
      isShowPopupPosition: false,
      isValid: true,
      formMode: 1,
      errors: {
        tenchucvu: "",
        dinhmucgiangday: "",
        ngayki: "",
        tenhopdong: "",
        ngaybatdau: "",
        ngayketthuc: "",
      },
    };
  },
  components: {
    Paginate,
    popUp,
  },
  watch: {
    txtSearch: function () {
      if (this.txtSearch == "") {
        this.getpagingStudent();
      }
    },
  },
  created() {
    this.getpagingStudent();
  },
  methods: {
    thongbao() {
      alert("Xác nhận đóng");
    },
    saveDataKyLuat(data) {
      var me = this;
      console.log(data, "datakjdskdjksd");
      const toast = useToast();
      let obj = {
        IDKyLuat: data.IDKyLuat,
        IDNhanVien: this.currentIdNhanVien,
        TenKL: data.TenKL,
        HinhThucKL: data.HinhThucKL,
        LyDoKL: data.LyDoKL,
        DiaDiemKL: data.DiaDiemKL,
        NgayKL: data.NgayKL,
      };
      try {
        axios
          .post(`https://localhost:44301/api/kiluat`, obj)
          .then(function(res) {
            console.log(res.data);
            toast.success("Thêm dữ liệu thành công", {timeout :2000 });
            me.isOpenPopupFormEditPosition = false;
            me.getListKiLuat(me.IDNV);
          })

          .catch(function () {
            console.log("error");
            toast.error("Thêm dữ liệu thất bại", {timeout :2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupContract(item) {
      this.isOpenPopupContract = true;
      this.currentIdNhanVien = item.IDNhanVien;
      this.currentNameNhanVien = item.TenNV;
      this.MaNV = item.MaNV;
      this.getListKiLuat();
    },
    getListKiLuat() {
      var me = this;
      try {
        axios
          .get(`https://localhost:44301/api/kiluat/${this.currentIdNhanVien}`)
          .then(function (res) {
            me.dataListKiLuat = res.data;
            console.log(res.data);
            for (const item of me.dataListKiLuat) {
              console.log(item);
            }
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupDeleteNotifi(item) {
      this.idDelete = "";
      this.isShowPopupPosition = true;
      this.IDNhanVienD = item.IDNhanVien;
      this.IDTTH = item.IDKT;
      console.log({ item });

      this.mess = "Bạn có chắc chắn muốn xóa thông tin này không?";
    },
    deletePosition(value) {
      this.isShowPopupPosition = value;
      const me = this;
      const toast = useToast();
      try {
        axios
          .delete(`https://localhost:44301/api/khenthuong/${this.IDTTH}`)
          .then(function () {
            me.getDataInfoBonus(me.IDNV);
            toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
          })
          .catch(function () {
            toast.error("xóa dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },

    OpenPopupPosition(item) {
      console.log("skjdksjdksjd", item);
      this.isOpenPopupPosition = true;
      this.currentIdNhanVien = item.IDNhanVien;
      this.currentNameNhanVien = item.TenNV;
      this.MaNV = item.MaNV;
      this.IDNV = item.IDNhanVien;
      this.getDataInfoBonus(item.IDNhanVien);
    },
    getDataInfoBonus(id) {
      try {
        axios
          .get(`https://localhost:44301/api/khenthuong/${id}`)
          .then((res) => {
            this.dataInfoBonus = res.data;
            console.log(res.data, "jshdjshdj");
          })
          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupFormAddPosition() {
      this.isOpenPopupFormAddPosition = true;
      (this.suaChucVu = {}), (this.suaChucVu.IDNhanVien = this.IDNV);
    },
    btnAddPosition() {
      var me = this;
      const toast = useToast();
      me.suaChucVu.IDNhanVien = me.IDNV;
      console.log(me.suaChucVu);
      try {
        axios
          .post("https://localhost:44301/api/chucvu", this.suaChucVu)
          .then(function (res) {
            console.log(res);
            me.isOpenPopupFormAddPosition = false;
            toast.success("thêm dữ liệu thành công", { timeout: 2000 });
            console.log("sdahjkfja", me.IDNV, me);
            me.getDataInfoBonus(me.IDNV);
          })
          .catch(function () {
            console.log("error");
            toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    savePosition() {
      this.validateName();
      this.validateNorm();
      if (this.isValid == true) {
        if (this.formMode == 1) {
          this.btnAddPosition();
        } else {
          this.btnEditPosition();
        }
      }
    },
    AddDataInfoBonus(data) {
      var me = this;
      const toast = useToast();
      me.suaChucVu.IDNhanVien = me.IDNV;
      console.log({ me });
      let obj = {
        IDNhanVien: me.IDNV,
        NgayKT: data?.NgayKT,
        HinhThucKT: data?.HinhThucKT,
        LyDoKT: data?.LyDoKT,
      };

      try {
        axios
          .post(`https://localhost:44301/api/khenthuong`, obj)
          .then(function (res) {
            console.log(res.data);
            toast.success("Thêm liệu thành công", { timeout: 2000 });
            me.isOpenPopupFormEditPosition = false;
            me.getDataInfoBonus(me.IDNV);
          })
          .catch(function () {
            console.log("error");
            toast.error("Thêm liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupFormEditPosition(item) {
      console.log({ item });
      this.dataEditInfoBonus = item;
      this.isOpenPopupFormEditPosition = true;
      this.suaChucVu = item;
      this.IDTTH = item.IDKT;
    },
    btnEditPosition(data) {
      var me = this;
      console.log(data, "datakjdskdjksd");
      const toast = useToast();
      let obj = {
        IDKT: me.IDTTH,
        IDNhanVien: me.IDNV,
        TenKT: "hello",
        NgayKT: this.formatDate(data.NgayKT),
        HinhThucKT: data.HinhThucKT,
        LyDoKT: data.LyDoKT,
        DiaDiemKT: "string",
      };

      axios
        .put(`https://localhost:44301/api/khenthuong/${me.IDTTH}`, obj)
        .then(function (res) {
          console.log(res);
          toast.success("sửa dữ liệu thành công", { timeout: 2000 });
          me.isOpenPopupFormEditPosition = false;
          me.getDataInfoBonus(me.IDNV);
        })
        .catch(function (err) {
          console.log("error", err);
          toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
        });
    },
    btnEditContract(data) {
      var me = this;
      console.log(data, "datakjdskdjksd");
      const toast = useToast();
      let obj1 = {
        IDKyLuat: data.IDKyLuat,
        IDNhanVien: data.IDNhanVien,
        HinhThucKL: data.HinhThucKL,
        LyDoKL: data.LyDoKL,
        NgayKL: this.formatDate(data.NgayKL),
      };

      axios
        .put(`https://localhost:44301/api/kiluat/${data.IDKyLuat}`, obj1)
        .then(function (res) {
          console.log(res);
          toast.success("sửa dữ liệu thành công", { timeout: 2000 });
          me.isOpenPopupFormEditPosition = false;
          me.getListKiLuat(me.IDNV);
        })
        .catch(function (err) {
          console.log("error", err);
          toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
        });
    },

    OpenPopupFormEditContract(item) {
      console.log({ item });
      this.isOpenPopupFormEditContract = true;
      this.dataEditContract = item;
      this.IDTTH = item.IDKT;
    },
    btnEditPositionContract(data) {
      var me = this;
      console.log(data, "datakjdskdjksd");
      const toast = useToast();
      let obj = {
        IDKT: me.IDTTH,
        IDNhanVien: me.IDNV,
        TenKT: "hello",
        NgayKT: this.formatDate(data.NgayKT),
        HinhThucKT: data.HinhThucKT,
        LyDoKT: data.LyDoKT,
        DiaDiemKT: "string",
      };

      me.suaChucVu.IDNhanVien = me.IDNV;
      axios
        .put(`https://localhost:44301/api/khenthuong/${me.IDTTH}`, obj)
        .then(function (res) {
          console.log(res);
          toast.success("sửa dữ liệu thành công", { timeout: 2000 });
          me.isOpenPopupFormEditPosition = false;
          me.getDataInfoBonus(me.IDNV);
        })
        .catch(function (err) {
          console.log("error", err);
          toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
        });
    },

    OpenPopupFormAddContract() {
      this.isOpenPopupFormAddContract = true;
      (this.suaHopDong = {}), (this.suaHopDong.IDNhanVien = this.IDNV);
    },
    btnAddContract() {
      var me = this;
      const toast = useToast();
      me.suaHopDong.IDNhanVien = me.IDNV;
      console.log(me.suaHopDong);
      try {
        axios
          .post("https://localhost:44301/api/hopdong", this.suaHopDong)
          .then(function (res) {
            console.log(res);
            me.isOpenPopupFormAddContract = false;
            toast.success("thêm dữ liệu thành công", { timeout: 2000 });
            me.getContract();
          })
          .catch(function () {
            console.log("error");
            toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    saveContract() {
      this.validateName();
      this.validateNorm();
      if (this.isValid == true) {
        if (this.formMode == 1) {
          this.btnAddContract();
        } else {
          this.btnEditContract();
        }
      }
    },

    OpenPopupFormAddFostering() {
      this.isOpenPopupFormAddFostering = true;
    },
    OpenPopupFormEditFostering() {
      this.isOpenPopupFormEditFostering = true;
    },
    OpenPopupAddNotifi() {
      this.isOpenPopupAddNotifi = true;
    },
    OpenPopupEditNotifi() {
      this.isOpenPopupEditNotifi = true;
    },
    OpenPopupAddNotifiCV() {
      this.isOpenPopupAddNotifiCV = true;
    },
    OpenPopupEditNotifiCV() {
      this.isOpenPopupEditNotifiCV = true;
    },
    OpenPopupDeleteNotifiCV(item) {
      this.idDelete = "";
      this.isShowPopupContract = true;
      this.isOpenPopupDeleteNotifiCV = true;
      this.idDelete = item.IDHopDong;
      this.IDKyLuat = item.IDKyLuat;
      this.mess = "Bạn có chắc chắn muốn xóa thông tin này không?";
    },
    deleteNotifiContract(value) {
      this.isShowPopupPosition = value;
      const me = this;
      const toast = useToast();
      try {
        axios
          .delete(`https://localhost:44301/api/kiluat/${this.IDKyLuat}`)
          .then(function () {
            toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
            me.getListKiLuat(me.IDNV);
          })
          .catch(function () {
            toast.error("xóa dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    noDelete(value) {
      this.isShowPopupContract = value;
      this.isShowPopupPosition = value;
    },
    getpagingStudent() {
      try {
        var me = this;
        me.isShowLoad = true;
        axios
          .get(
            `https://localhost:44301/api/nhanvien/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&IDKhoa=${this.IDKhoa}&pageNumber=${this.pageNumber}`
          )
          .then(function (res) {
            me.isShowLoad = false;
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
    gender(gender) {
      switch (gender) {
        case 0:
          gender = "Nam";
          break;
        case 1:
          gender = "Nữ";
          break;
        default:
          break;
      }
      return gender;
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
    validateName() {
      if (!this.suaChucVu.TenChucVu) {
        this.errors.tenchucvu = "Hình thức khen thưởng không được để trống!";
        this.isValid = false;
      } else {
        this.errors.tenchucvu = "";
        this.isValid = true;
      }
    },
    validateNorm() {
      if (!this.suaChucVu.DinhMucGiangDay) {
        this.errors.dinhmucgiangday = "Lý do khen thưởng không được để trống!";
        this.isValid = false;
      } else {
        this.errors.dinhmucgiangday = "";
        this.isValid = true;
      }
    },
  },
};
</script>
<style scoped>
@import url(../../css/page/bonusCis.css);
</style>
