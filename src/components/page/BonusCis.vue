<template>
  <!-- chuc vu -->
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
          <div class="maNV">Mã nhân viên: {{ currentIdNhanVien }}</div>
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
        <!-- <div class="btnDelete" style="bottom: -140px;">Xóa</div> -->
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
          <div class="maNV">Mã nhân viên: {{ currentIdNhanVien }}</div>
          <div class="tenNV">Tên nhân viên: {{ currentNameNhanVien }}</div>
          <div class="btnWrap">
            <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
            <div class="btnEdit">Sửa</div> -->
          </div>
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
        <!-- <div class="btnSave" @click="savePosition(dataAddInfoBonus)">Lưu</div> -->
        <div class="btnSave" @click="AddDataInfoBonus(dataAddInfoBonus)">Lưu</div>

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
          <div class="maNV">Mã nhân viên: {{ currentIdNhanVien }}</div>
          <div class="tenNV">Tên nhân viên: {{ currentNameNhanVien }}</div>
          <div class="btnWrap">
            <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
            <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <div class="form">
          <form action="">
            <div class="input__box">
              <label for="">Hình thức khen thưởng</label>
              <input type="text" v-model="dataEditInfoBonus.HinhThucKT" />
              <!-- <div class="invalid-feedback" v-if="errors.tenchucvu != ''">
                {{ errors.tenchucvu }}
              </div> -->
            </div>
            <div class="input__box">
              <label for="">Ngày khen thưởng</label>
              <input type="date" v-model="dataEditInfoBonus.NgayKT" />
            </div>

            <div class="input__box">
              <label for="">Lý do khen thưởng</label>
              <input type="text" v-model="dataEditInfoBonus.LyDoKT" />
              <!-- <div class="invalid-feedback" v-if="errors.dinhmucgiangday != ''">
                {{ errors.dinhmucgiangday }}
              </div> -->
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupEditNotifi = true">
          Hủy
        </div>
        <div class="btnSave" @click="btnEditPosition(dataEditInfoBonus)">Lưu</div>
      </div>
    </div>
    <!-- end open popup chuc vu   -->
    <!-- cảnh báo thêm chức vụ -->
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
    <!-- cảnh báo sửa chức vụ-->
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
          <div class="maNV">Mã nhân viên: {{ currentIdNhanVien }}</div>
          <div class="tenNV">Tên nhân viên: {{ currentNameNhanVien }}</div>
          <div class="btnWrap">
            <div class="btnAdd" @click="OpenPopupFormAddContract(item)">
              Thêm
            </div>
            <!-- <div class="btnEdit" @click="OpenPopupFormEditContract(item)">Sửa</div> -->
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
              <th>HÌnh thức kỷ luật</th>
              <th>Ngày kỷ luật</th>
              <th>Lý do</th>
              <th style="width: 100px">Chức năng</th>
            </tr>
            <tr></tr>
           
            <tr v-for="item of dataListKiLuat" :key="item.IDKyLuat" >
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
          <!-- <div class="btnDelete" style="bottom: -16px">Xóa</div> -->
        </div>
      </div>
    </div>
    <popUp
      v-show="isShowPopupContract"
      :msv="mess"
      @cancelNotifi="noDelete"
      @closeNotifi="deleteNotifiContract"
    ></popUp>

    <!-- them hop dong -->
    <div class="popup-bonus" v-if="isOpenPopupFormAddContract">
      <div class="bonus-formm">
        <div class="head-popup">
          <h3 class="title-heading">Thêm thông tin kỷ </h3>
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
          <div class="maNV">Mã nhân viên: {{ this.currentIdNhanVien }}</div>
          <div class="tenNV">Tên nhân viên: {{ this.currentNameNhanVien }}</div>
          <div class="btnWrap">
            <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
              <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <div class="form">
          <form action="">
            <div class="column">
              <div class="input__box">
                <label for="">Tên hợp đồng</label>
                <input
                  :class="errors.tenhopdong != '' ? 'border-red' : ''"
                  @blur="validateNameHD"
                  type="text"
                  v-model="dataAddKyLuat.TenKL"
                />
                <div class="invalid-feedback" v-if="errors.tenhopdong != ''">
                  {{ errors.tenhopdong }}
                </div>
              </div>
              <div class="input__box">
                <label for="">Ngày kỷ Luật</label>
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
    <!-- sua hop dong-->
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
          <div class="btnWrap">
            <!-- <div class="btnAdd" @click="OpenPopupFormAddContract(item)">Thêm</div>
              <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <div class="form">
          <form action="">
            <div class="column" style="display: block">
              <div class="input__box">
                <label for="">Thêm hình thức lỷ luật</label>
                <input type="text" v-model="suaHopDong.TenHD" />
                <!-- <div class="invalid-feedback" v-if="errors.tenhopdong != ''">
                  {{ errors.tenhopdong }}
                </div> -->
              </div>
              <br />
              <div class="input__box">
                <label for="">Chọn ngày kỷ luật</label>
                <input type="date" v-model="suaHopDong.NgayKi" />
                <!-- <div class="invalid-feedback" v-if="errors.ngayki != ''">
                  {{ errors.ngayki }}
                </div> -->
              </div>
            </div>
            <div class="column">
              <div class="input__box">
                <label for="">Thêm lý do kỷ luật</label>
                <textarea
                  v-model="suaHopDong.Mota"
                  style="width: 95%; height: 60px; margin-top: 5px"
                ></textarea>
              </div>
            </div>
          </form>
        </div>
        <div class="btnCancel" @click.stop="isOpenPopupEditNotifiCV = true">
          Hủy
        </div>
        <div class="btnSave" @click="btnEditContract">Lưu</div>
      </div>
    </div>
    <!-- end hop dong -->
    <!-- cảnh báo thêm hợp đồng -->
    <div class="notification-wrap" v-if="isOpenPopupAddNotifiCV">
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
    <!-- cảnh báo xóa hợp đồng-->
    <!-- <div class="notification-wrap" v-if="isOpenPopupDeleteNotifiCV">
      <div class="notification">
        <div class="warring">
          <div>
            <div class="icon-warning"></div>
          </div>
          <div class="warrning-title">Thông tin hợp đồng của sinh viên. Bạn có muốn xóa thông tin không?</div>
        </div>
        <div class="btn-wrap">
          <div class="btnNotifi btn-secondary"
            @click.stop="(isOpenPopupDeleteNotifiCV = false, isOpenPopupFormEditContract = false)">Hủy</div>
          <div class="btnNotifi btn-primary" @click="deleteDeleteNotifiCV">Xóa</div>
        </div>
      </div>
    </div> -->
    <!-- cảnh báo sửa hợp đồng-->
    <div class="notification-wrap" v-if="isOpenPopupEditNotifiCV">
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

    <h3 class="header-bd">Quản lý hợp đồng</h3>
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
            <!-- <th class="sticky-left-top checkbox" colspan="1" style="min-width: 30px !important; text-align: center">
              <input ref="checkall" type="checkBox" class="check-all" style="width: 18px; height: 18px" />
            </th> -->
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
            <td>{{ item.GioiTinh }}</td>
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
      dataAddKyLuat:{},
      currentIdNhanVien:null,
      currentNameNhanVien:"",
      dataInfoBonus: {},
      dataAddInfoBonus:{},
      dataListKiLuat:{},
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
    saveDataKyLuat(data){
      let obj = {
        "IDKyLuat": data.IDKyLuat,
        "IDNhanVien": this.currentIdNhanVien,
        "TenKL": data.TenKL,
        "HinhThucKL": data.HinhThucKL,
        "LyDoKL": data.LyDoKL,
        "DiaDiemKL": data.DiaDiemKL,
        "NgayKL": data.NgayKL
      }
      try {
        

        axios
          .post(`https://localhost:44301/api/kyluat/${this.currentIdNhanVien}`, obj)
          .then(res=>{
            console.log(res)
          })

          .catch(function () {
            console.log("Not create punish!");
          });
      } catch (error) {
        console.log(error);
      }
    },
    getContract() {
      try {
        var me = this;

        axios
          .get(`https://localhost:44301/api/hopdong/${this.IDNV}`)
          .then(function (res) {
            me.hopdong = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupContract(item) {
      this.isOpenPopupContract = true;
      this.currentIdNhanVien = item.IDNhanVien
      this.currentNameNhanVien = item.TenNV
      // this.MaNV = item.MaNV;
      // this.TenNV = item.TenNV;
      // this.IDNV = item.IDNhanVien;
      this.getListKiLuat();
    },
    getListKiLuat() {
      try {
       

        axios
          .get(`https://localhost:44301/api/kiluat/${this.currentIdNhanVien}`)
          .then(function (res) {
            console.log(res.data,"sdjhsjdh")
            this.dataListKiLuat = res.data;
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupFostering(item) {
      this.isOpenPopupFostering = true;
      this.MaNV = item.MaNV;
      this.TenNV = item.TenNV;
    },
    getPosition() {
      try {
        var me = this;

        axios
          .get(`https://localhost:44301/api/chucvu/${this.IDNV}`)
          .then(function (res) {
            me.chucvu = res.data;
            console.log(me.chucvu);
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },

    OpenPopupPosition(item) {
      console.log(item, "skjdksjdksjd")
      this.isOpenPopupPosition = true;
      this.currentIdNhanVien = item.IDNhanVien
      this.currentNameNhanVien = item.TenNV
      // this.MaNV = item.MaNV
      // this.TenNV = item.TenNV
      // this.IDNV = item.IDNhanVien
      this.getDataInfoBonus(item.IDNhanVien)
    },
    getDataInfoBonus(id){
      try {
        axios
          .get(`https://localhost:44301/api/khenthuong/${id}`)
          .then(res=>{
            this.dataInfoBonus = res.data
            console.log(res.data,"jshdjshdj")
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
            me.getPosition();
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
    AddDataInfoBonus(data){
      let obj = {
        IDKT: data,
        IDNhanVien: data,
        TenKT: data,
        NgayKT: data,
        HinhThucKT: data,
        LyDoKT: data
      }
      var me = this;
      const toast = useToast();
      me.suaChucVu.IDNhanVien = me.IDNV;
      try {
        axios
          .put(
            `https://localhost:44301/api/khenthuong/${this.currentIdNhanVien}`,obj
          )
          .then(function (res) {
            console.log(res);
            toast.success("sửa dữ liệu thành công", { timeout: 2000 });
            me.isOpenPopupFormEditPosition = false;
            me.getPosition();
          })
          .catch(function () {
            console.log("error");
            toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupFormEditPosition(item) {
      this.dataEditInfoBonus = item
      this.isOpenPopupFormEditPosition = true;
      this.suaChucVu = item;
      item.ThoiGianBatDau = this.formatDate(item.ThoiGianBatDau);
      this.suaChucVu.ThoiGianBatDau = item.ThoiGianBatDau;
      item.ThoiGianKetThuc = this.formatDate(item.ThoiGianKetThuc);
      this.suaChucVu.ThoiGianKetThuc = item.ThoiGianKetThuc;
    },
    btnEditPosition(data) {
      var me = this;
      console.log(data,"datakjdskdjksd")
      const toast = useToast();
      let obj ={
        IDKT: data.IDKT,
        IDNhanVien: data.IDNhanVien,
        TenKT: data.TenKT,
        NgayKT: this.formatDate(data.NgayKT),
        HinhThucKT: data.HinhThucKT,
        LyDoKT: data.LyDoKT
      }
      me.suaChucVu.IDNhanVien = me.IDNV;
      try {
        axios
          .put(
            `https://localhost:44301/api/khenthuong/${data.IDKT}`,obj
          )
          .then(function (res) {
            console.log(res);
            toast.success("sửa dữ liệu thành công", { timeout: 2000 });
            me.isOpenPopupFormEditPosition = false;
            me.getPosition();
          })
          .catch(function () {
            console.log("error");
            toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
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
      this.validateNameHD();
      this.validateNgayKi();
      this.validateNgayBD();
      this.validateNgayKT();
      if (this.isValid == true) {
        if (this.formMode == 1) {
          this.btnAddContract();
        } else {
          this.btnEditContract();
        }
      }
    },
    OpenPopupFormEditContract(item) {
      this.isOpenPopupFormEditContract = true;
      this.suaHopDong = item;
      item.NgayKi = this.formatDate(item.NgayKi);
      this.suaHopDong.NgayKi = item.NgayKi;
      item.NgayBD = this.formatDate(item.NgayBD);
      this.suaHopDong.NgayBD = item.NgayBD;
      item.NgayKT = this.formatDate(item.NgayKT);
      this.suaHopDong.NgayKT = item.NgayKT;
    },
    btnEditContract() {
      var me = this;
      const toast = useToast();
      me.suaHopDong.IDNhanVien = me.IDNV;
      try {
        axios
          .put(
            `https://localhost:44301/api/hopdong/${this.suaHopDong.IDHopDong}`,
            this.suaHopDong
          )
          .then(function (res) {
            console.log(res);
            toast.success("sửa dữ liệu thành công", { timeout: 2000 });
            me.isOpenPopupFormEditContract = false;
            me.getContract();
          })
          .catch(function () {
            console.log("error");
            toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
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
      this.mess = "Bạn có chắc chắn muốn xóa thông tin hợp đồng này không?";
    },
    deleteNotifiContract(value) {
      this.isShowPopupContract = value;
      var me = this;
      const toast = useToast();
      try {
        axios
          .delete(`https://localhost:44301/api/hopdong/${this.idDelete}`)
          .then(function (res) {
            console.log(res);
            toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
            me.getContract();
          })

          .catch(function () {
            toast.error("xóa dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupDeleteNotifi(item) {
      this.idDelete = "";
      this.isShowPopupPosition = true;
      // this.isOpenPopupDeleteNotifi = true;
      this.idDelete = item.IDChucVu;
      this.mess = "Bạn có chắc chắn muốn xóa thông tin chức vụ này không?";
    },
    deletePosition(value) {
      this.isShowPopupPosition = value;
      var me = this;
      const toast = useToast();
      try {
        axios
          .delete(`https://localhost:44301/api/chucvu/${this.idDelete}`)
          .then(function (res) {
            console.log(res);
            toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
            me.getPosition();
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
        // document.getElementsByClassName('ten').classList.add('borderRed')
      } else {
        this.errors.tenchucvu = "";
        this.isValid = true;
      }
    },
    validateNorm() {
      if (!this.suaChucVu.DinhMucGiangDay) {
        this.errors.dinhmucgiangday = "Lý do khen thưởng không được để trống!";
        this.isValid = false;
        // document.getElementsByClassName('ten').classList.add('borderRed')
      } else {
        this.errors.dinhmucgiangday = "";
        this.isValid = true;
      }
    },
    // validateNameHD() {
    //   if (!this.suaHopDong.TenHD) {
    //     this.errors.tenhopdong = "Tên hợp đồng không được để trống!";
    //     this.isValid = false;
    //     // document.getElementsByClassName('ten').classList.add('borderRed')
    //   } else {
    //     this.errors.tenhopdong = "";
    //     this.isValid = true;
    //   }
    // },
    // // validateNgayKi() {
    // //   if (!this.suaHopDong.NgayKi) {
    // //     this.errors.ngayki = "Ngày kí không được để trống!";
    // //     this.isValid = false;
    // //     // document.getElementsByClassName('ten').classList.add('borderRed')
    // //   } else {
    // //     this.errors.ngayki = "";
    // //     this.isValid = true;
    // //   }
    // // },
    // validateNgayBD() {
    //   if (!this.suaHopDong.NgayBD) {
    //     this.errors.ngaybatdau = "Ngày bắt đầu không được để trống!";
    //     this.isValid = false;
    //     // document.getElementsByClassName('ten').classList.add('borderRed')
    //   } else {
    //     this.errors.ngaybatdau = "";
    //     this.isValid = true;
    //   }
    // },
    // validateNgayKT() {
    //   if (!this.suaHopDong.NgayKT) {
    //     this.errors.ngayketthuc = "Ngày kết thúc không được để trống!";
    //     this.isValid = false;
    //     // document.getElementsByClassName('ten').classList.add('borderRed')
    //   } else {
    //     this.errors.ngayketthuc = "";
    //     this.isValid = true;
    //   }
    // },
  },

  //
};
</script>
<style scoped>
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
@import url(../../css/page/bonusCis.css);
</style>
