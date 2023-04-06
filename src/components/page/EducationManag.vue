<template>
  <!-- hoc van -->
  <div class="body">
    <div class="popup-bonus" v-if="isOpenPopupEducation">
      <div class="bonus-form">
        <div class="head-popup">
          <h3 class="title-heading">Trình độ học vấn</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupEducation = false">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>
        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <div class="btnAdd" @click="OpenPopupFormAddEducation">Thêm</div>
            <!-- <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
          <tr>
            <th>Trình độ lý luận chính trị</th>
            <th>Trình quản lý giáo dục</th>
            <th>Trình độ ngoại ngữ</th>
            <th>Trình độ tin học</th>
            <th>Chứng chỉ ngoại ngữ</th>
            <th>Tình trạng học vấn</th>
            <th style="width: 100px;">Chức năng</th>
          </tr>
          <tr>
          </tr>
          <tr v-for="item of hocvan" :key="item.IDHocVan">
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.TrinhDoLLCT }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.TrinhDoQLGD }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.TrinhDoQLNN }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.TrinhDoTinHoc }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.ChungChiNgoaiNgu }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.TinhTrangHocVan }}</td>

            <td ref="func" class="td-item-final td-func"
              style="background-color: #fff; align-items: center; border: 1px solid #c7c7c7; column-gap: 10px;"
              colspan="12">
              <div class="icon icon-edit" @click="OpenPopupFormEditEducation(item)"></div>
              <div class="icon icon-delete" @click="deleteEducation(item)"></div>
            </td>
          </tr>
        </table>
      </div>
    </div>
    <popUp v-show="isShowPopupEdu" :msv="mess" @cancelNotifi="noDelete" @closeNotifi="deleteOK"></popUp>
    <!-- them hoc van -->
    <div class="popup-bonus" v-if="isOpenPopupFormAddEducation">
      <div class="action-form" @keypress.enter="btnAddEducation">
        <div class="head-popup">
          <h3 class="title-heading">Thêm trình độ học vấn</h3>
          <div class="btn-close-popup" @click.stop="showAddEducation">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>

        <div style="display: flex; font-weight: 600; margin: 20px 0;">
          <div class="maNV" style="padding-right: 40px;">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Chứng chỉ ngoại ngữ <span>*</span> : </label>
            <input :class="errors.chungchingoaingu != '' ? 'border-red' : ''" @blur="validateCCNN" type="text"
              v-model="suaHocVan.ChungChiNgoaiNu">
            <div class="invalid-feedback" v-if="errors.chungchingoaingu != ''">
              {{ errors.chungchingoaingu }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">

            <label for="">Tình trạng học vấn<span>*</span>: </label>
            <input :class="errors.tinhtranghocvan != '' ? 'border-red' : ''" @blur="validateTTHV" type="text"
              v-model="suaHocVan.TinhTrangHocVan">
            <div class="invalid-feedback" v-if="errors.tinhtranghocvan != ''">
              {{ errors.tinhtranghocvan }}
            </div>
          </div>
          </div>

        <div class="column">
          <div class="input__box">

            <label for="">Trình quản lý giáo dục <span>*</span> : </label>
            <input :class="errors.quanligiaoduc != '' ? 'border-red' : ''" @blur="validateQLGD" type="text"
              v-model="suaHocVan.TrinhDoQLGD">

            <div class="invalid-feedback" v-if="errors.quanligiaoduc != ''">
              {{ errors.quanligiaoduc }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Trình độ chính trị: </label>
            <input type="text" v-model="suaHocVan.TrinhDoLLCT">
          </div>
        </div>

        <div class="column">
          <div class="input__box">
            <label for="">Trình độ ngoại ngữ: </label>
            <input type="text" v-model="suaHocVan.TrinhDoQLNN">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Trình độ tin học: </label>
            <input type="text" v-model="suaHocVan.TrinhDoTinHoc">
          </div>
        </div>

        <div class="btnCancel" @click.stop="isShowNotifi = true">Hủy</div>
        <div class="btnSave" @click="btnAddEducation">Lưu</div>
      </div>
    </div>
    <Notifi v-show="isShowNotifi" @closeNotifi="closeNo" @cancelNotifi="cancelForm"></Notifi>
    <!-- sua hoc van-->
    <div class="popup-bonus" v-if="isOpenPopupFormEditEducation">
      <div class="action-form" @keypress.enter="editEducation">
        <div class="head-popup">
          <h3 class="title-heading">Sửa trình độ học vấn</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupFormEditEducation = false">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>
        <div style="display: flex; font-weight: 600; margin: 20px 0;">
          <div class="maNV" style="padding-right: 40px;">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Chứng chỉ ngoại ngữ <span>*</span> : </label>
            <input :class="errors.chungchingoaingu != '' ? 'border-red' : ''" @blur="validateCCNN" type="text"
              v-model="suaHocVan.ChungChiNgoaiNgu">
            <div class="invalid-feedback" v-if="errors.chungchingoaingu != ''">
              {{ errors.chungchingoaingu }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Tình trạng học vấn <span>*</span> : </label>
            <input :class="errors.tinhtranghocvan != '' ? 'border-red' : ''" @blur="validateTTHV" type="text"
              v-model="suaHocVan.TinhTrangHocVan">
            <div class="invalid-feedback" v-if="errors.tinhtranghocvan != ''">
              {{ errors.tinhtranghocvan }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Trình quản lý giáo dục <span>*</span> : </label>
            <input :class="errors.quanligiaoduc != '' ? 'border-red' : ''" @blur="validateQLGD" type="text"
              v-model="suaHocVan.TrinhDoQLGD">
            <div class="invalid-feedback" v-if="errors.quanligiaoduc != ''">
              {{ errors.quanligiaoduc }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Trình độ chính trị: </label>
            <input type="text" v-model="suaHocVan.TrinhDoLLCT">
          </div>
        </div>

        <div class="column">
          <div class="input__box">
            <label for="">Trình độ ngoại ngữ: </label>
            <input type="text" v-model="suaHocVan.TrinhDoQLNN">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Trình độ tin học: </label>
            <input type="text" v-model="suaHocVan.TrinhDoTinHoc">
          </div>
        </div>
        <div class="btnCancel" @click.stop="isShowEditEdu = true">Hủy</div>
        <div class="btnSave" @click="editEducation">Lưu</div>
      </div>
    </div>
    <Notifi v-show="isShowEditEdu" @closeNotifi="closeNo" @cancelNotifi="cancelFormEditEdu"></Notifi>
    <!-- end open popup hoc van   -->

    <!-- dao tao -->
    <div class="popup-bonus" v-if="isOpenPopupTrain">
      <div class="bonus-form">
        <div class="head-popup">
          <h3 class="title-heading">Quá trình đào tạo</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupTrain = false">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>
        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <div class="btnAdd" @click="OpenPopupFormAddTrain">Thêm</div>
            <!-- <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
          <tr>
            <th>Thời gian bắt đầu</th>
            <th>Thời gian kết thúc</th>
            <th>Nơi đào tạo</th>
            <th>Chuyên ngành</th>
            <th>Hình thức đào tạo</th>
            <th>Bằng cấp</th>
            <th style="width: 100px;">Chức năng</th>
          </tr>
          <tr>
          </tr>
          <tr v-for="item of daotao" :key="item.IDDaoTao">
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ formatDate(item.ThoiGianBatDau) }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ formatDate(item.ThoiGianKetThuc) }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.NoiDaoTao }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.ChuyenNganh }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.HinhThucDaoTao }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.BangCap }}</td>
            <td ref="func" class="td-item-final td-func"
              style="background-color: #fff; align-items: center; border: 1px solid #c7c7c7; column-gap: 10px;"
              colspan="12">
              <div class="icon icon-edit" @click="OpenPopupFormEditTrain(item)"></div>
              <div class="icon icon-delete" @click="deleteTrain(item)"></div>
            </td>
          </tr>
        </table>

      </div>
    </div>

    <popUp v-show="isShowPopupTrain" :msv="mess" @cancelNotifi="noDelete" @closeNotifi="deleteTrainOK"></popUp>
    <!-- them dao tao -->
    <div class="popup-bonus" v-if="isOpenPopupFormAddTrain">
      <div class="action-form" @keypress.enter="btnAddTraning">
        <div class="head-popup">
          <h3 class="title-heading">Thêm quá trình đào tạo</h3>
          <div class="btn-close-popup" @click.stop="showAddTrain">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>

        <div style="display: flex; font-weight: 600; margin: 20px 0;">
          <div class="maNV" style="padding-right: 40px;">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Chuyên ngành <span>*</span> : </label>
            <input :class="errors.chuyennganhdaotao != '' ? 'border-red' : ''" @blur="validateCNDT" type="text"
              v-model="suaDaotao.ChuyenNganh">
            <div class="invalid-feedback" v-if="errors.chuyennganhdaotao != ''">
              {{ errors.chuyennganhdaotao }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Hình thức đào tạo: </label>
            <input :class="errors.hinhthucdaotao != '' ? 'border-red' : ''" @blur="validateHinhThuc" type="text"
              v-model="suaDaotao.HinhThucDaoTao">
            <div class="invalid-feedback" v-if="errors.hinhthucdaotao != ''">
              {{ errors.hinhthucdaotao }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Học vấn <span>*</span> : </label>
            <input :class="errors.bangcap != '' ? 'border-red' : ''" @blur="validateBangCap" type="text"
              v-model="suaDaotao.BangCap">
            <div class="invalid-feedback" v-if="errors.bangcap != ''">
              {{ errors.bangcap }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Thời gian bắt đầu: </label>
            <input type="date" v-model="suaDaotao.ThoiGianBatDau">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Thời gian kết thúc: </label>
            <input type="date" format="dd/mm/yyyy" placeholder="dd-mm-yyyy" v-model="suaDaotao.ThoiGianKetThuc">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Nơi đào tạo: </label>
            <input type="text" v-model="suaDaotao.NoiDaoTao">
          </div>
        </div>

        <div class="btnCancel" @click.stop="isShowAddTrain = true">Hủy</div>
        <div class="btnSave" @click="btnAddTraning">Lưu</div>
      </div>
    </div>
    <Notifi v-show="isShowAddTrain" @closeNotifi="closeNo" @cancelNotifi="cancelFormAddTrain"></Notifi>
    <!-- sua dao tao-->
    <div class="popup-bonus" v-if="isOpenPopupFormEditTrain">
      <div class="action-form" @keypress.enter="editTrain">
        <div class="head-popup">
          <h3 class="title-heading">Sửa quá trình đào tạo</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupFormEditTrain = false">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>
        <div style="display: flex; font-weight: 600; margin: 20px 0;">
          <div class="maNV" style="padding-right: 40px;">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Chuyên ngành <span>*</span> : </label>
            <input :class="errors.chuyennganhdaotao != '' ? 'border-red' : ''" @blur="validateCNDT" type="text"
              v-model="suaDaotao.ChuyenNganh">
            <div class="invalid-feedback" v-if="errors.chuyennganhdaotao != ''">
              {{ errors.chuyennganhdaotao }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Hình thức đào tạo <span>*</span> : </label>
            <input :class="errors.hinhthucdaotao != '' ? 'border-red' : ''" @blur="validateHinhThuc" type="text"
              v-model="suaDaotao.HinhThucDaoTao">
            <div class="invalid-feedback" v-if="errors.hinhthucdaotao != ''">
              {{ errors.hinhthucdaotao }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Học vấn <span>*</span> : </label>
            <input :class="errors.bangcap != '' ? 'border-red' : ''" @blur="validateBangCap" type="text"
              v-model="suaDaotao.BangCap">
            <div class="invalid-feedback" v-if="errors.bangcap != ''">
              {{ errors.bangcap }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Thời gian bắt đầu: </label>
            <input type="date" v-model="suaDaotao.ThoiGianBatDau">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Thời gian kết thúc: </label>
            <input type="date" format="dd/mm/yyyy" placeholder="dd-mm-yyyy" v-model="suaDaotao.ThoiGianKetThuc">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Nơi đào tạo: </label>
            <input type="text" v-model="suaDaotao.NoiDaoTao">
          </div>
        </div>

        <div class="btnCancel" @click.stop="isShowEditTrain = true">Hủy</div>
        <div class="btnSave" @click="editTrain">Lưu</div>
      </div>
    </div>
    <Notifi v-show="isShowEditTrain" @closeNotifi="closeNo" @cancelNotifi="cancelFormEditTrain"></Notifi>
    <!-- end dao tao -->

    <!-- boi duong -->
    <div class="popup-bonus" v-if="isOpenPopupFostering">
      <div class="bonus-form">
        <div class="head-popup">
          <h3 class="title-heading">Quá trình bồi dưỡng</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupFostering = false">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>

        <div class="education-header">
          <div class="maNV">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
          <div class="btnWrap">
            <div class="btnAdd" @click="OpenPopupFormAddFostering(item)">Thêm</div>
            <!-- <div class="btnEdit">Sửa</div> -->
          </div>
        </div>
        <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
          <tr>
            <th>Thời gian bắt đầu</th>
            <th>Thời gian kết thúc</th>
            <th>Nội dung </th>
            <th>Nơi bồi dưỡng</th>
            <th>Bằng cấp</th>
            <th style="width:100px;">Chức năng</th>
          </tr>
          <tr>
          </tr>
          <tr v-for="item of boiduong" :key="item.IDBoiDuong">
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ formatDate(item.ThoiGianBatDau) }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ formatDate(item.ThoiGianKetThuc) }}</td>
            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.NoiDungBoiDuong }}</td>

            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.DiaDiem }}</td>

            <td style="border: 1px solid #c7c7c7; width: 150px;">{{ item.VanBangChungChi }}</td>

            <td ref="func" class="td-item-final td-func"
              style="background-color: #fff; align-items: center; border: 1px solid #c7c7c7; column-gap: 10px;"
              colspan="12">
              <div class="icon icon-edit" @click="OpenPopupFormEditFostering(item)"></div>
              <div class="icon icon-delete" @click="deleteFos(item)"></div>
            </td>
          </tr>
        </table>
      </div>
    </div>
    <Notifi v-show="isShowAddFos" @closeNotifi="closeNo" @cancelNotifi="cancelFormAddFos"></Notifi>
    <popUp v-show="isShowPopupFos" :msv="mess" @cancelNotifi="noDelete" @closeNotifi="deleteFosOK"></popUp>
    <!-- them boi duong -->
    <div class="popup-bonus" v-if="isOpenPopupFormAddFostering">
      <div class="action-form" @keypress.enter="btnAddFos">
        <div class="head-popup">
          <h3 class="title-heading">Thêm quá trình bồi dưỡng</h3>
          <div class="btn-close-popup" @click.stop="showAddFos">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>

        <div style="display: flex; font-weight: 600; margin: 20px 0;">
          <div class="maNV" style="padding-right: 40px;">Mã nhân viên: {{ MaNV }}</div>
          <div class="tenNV">Tên nhân viên: {{ TenNV }}</div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Nội dung <span>*</span> : </label>
            <input :class="errors.noidungboiduong != '' ? 'border-red' : ''" @blur="validateNDBD" type="text"
              v-model="suaBoiDuong.NoiDungBoiDuong">
            <div class="invalid-feedback" v-if="errors.noidungboiduong != ''">
              {{ errors.noidungboiduong }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Nơi bồi dưỡng <span>*</span> : </label>
            <input :class="errors.noiboiduong != '' ? 'border-red' : ''" @blur="validateNoiBD" type="text"
              v-model="suaBoiDuong.DiaDiem">
            <div class="invalid-feedback" v-if="errors.noiboiduong != ''">
              {{ errors.noiboiduong }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Bằng cấp <span>*</span> : </label>
            <input :class="errors.vanbangchungchi != '' ? 'border-red' : ''" @blur="validateVBCC" type="text"
              v-model="suaBoiDuong.VanBangChungChi">
            <div class="invalid-feedback" v-if="errors.vanbangchungchi != ''">
              {{ errors.vanbangchungchi }}
            </div>
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Thời gian bắt đầu: </label>
            <input type="date" v-model="suaBoiDuong.ThoiGianBatDau">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Thời gian kết thúc: </label>
            <input type="date" v-model="suaBoiDuong.ThoiGianKetThuc">
          </div>
        </div>

        <div class="btnCancel" @click.stop="isShowAddFos = true">Hủy</div>
        <div class="btnSave" @click="btnAddFos">Lưu</div>
      </div>
    </div>
    <Notifi v-show="isShowEditFos" @closeNotifi="closeNo" @cancelNotifi="cancelFormEditFos"></Notifi>
    <!-- sua boi duong-->
    <div class="popup-bonus" v-if="isOpenPopupFormEditFostering">
      <div class="action-form" @keypress.enter="btnEditFos">
        <div class="head-popup">
          <h3 class="title-heading">Sửa quá trình bồi dưỡng</h3>
          <div class="btn-close-popup" @click.stop="isOpenPopupFormEditFostering = false">
            <div class="icon">
              <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                stroke="currentColor" class="w-6 h-6">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
              </svg>
            </div>
          </div>
        </div>
        <div style="display: flex; font-weight: 600; margin: 20px 0;">
          <div class="maNV" style="padding-right: 40px;">Mã nhân viên: abc</div>
          <div class="tenNV">Tên nhân viên: Ngô Văn Tùng</div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Thời gian bắt đầu: </label>
            <input type="date" v-model="suaBoiDuong.ThoiGianBatDau">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Thời gian kết thúc: </label>
            <input type="date" v-model="suaBoiDuong.ThoiGianKetThuc">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Nội dung: </label>
            <input type="text" v-model="suaBoiDuong.NoiDungBoiDuong">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Nơi bồi dưỡng: </label>
            <input type="text" v-model="suaBoiDuong.DiaDiem">
          </div>
        </div>
        <div class="column">
          <div class="input__box">
            <label for="">Bằng cấp: </label>
            <input type="text" v-model="suaBoiDuong.VanBangChungChi">
          </div>
        </div>
        <div class="btnCancel" @click.stop="isShowEditFos = true">Hủy</div>
        <div class="btnSave" @click="btnEditFos">Lưu</div>
      </div>
    </div>
    <!--end boi duong  -->

    <h3 class="header-bd">Đào tạo</h3>
    <div class="body-header">
      <div class="row-input">
        <div class="input">
          <input type="text" class="search" placeholder="Tìm kiếm" v-model="txtSearch"
            @keypress.enter="getPagingEmployee" />
          <div class="icon-search icon"></div>
        </div>
      </div>
    </div>
    <!-- table -->
    <div id="m-table" class="m-table">
      <table id="tbEmployee" class="table" style="width: 100%;">
        <thead>
          <tr>

            <th class="text-center" style="min-width: 40px; text-align: center">STT</th>
            <th style="width: 40px">Mã nhân viên </th>
            <th>Họ và tên</th>
            <th>Ngày sinh</th>
            <th style="width: 40px">Giới tính</th>
            <th style="width: 40px">Khoa</th>
            <div class="th-item-final sticky-right-top">
              <th style="height: 42px; padding-top: 11px">Trình độ học vấn</th>
              <th>Quá trình đào tạo</th>
              <th>Quá trình bồi dưỡng</th>
            </div>

            <!-- <th
                class="th-item-final sticky-right-top"
                colspan="12"
                style="min-width: 100px; text-align: center"
              >
                <div class="th-item">
                  <span class="table-text">Chi tiết</span>
                </div>
              </th> -->

          </tr>
        </thead>
        <tbody>
          <tr v-for=" (item, i) of students" :key="item.StudentID" ref="row">

            <td class="text-center">{{ i + 1 }}</td>
            <td style="width: 40px">{{ item.MaNV }}</td>
            <td>{{ item.TenNV }}</td>
            <td>{{ formatDate(item.NgaySinh) }}</td>
            <td style="width: 40px">{{ gender(item.GioiTinh) }}</td>
            <td style="width: 40px">{{ item.TenKhoa }}</td>
            <div class="th-item-final sticky-right-top">
              <td>
                <div colspan="1" style="width: 121px;  box-sizing: border-box;" class="desc text-center"
                  @click="OpenPopupEducation(item)">
                  Xem chi tiết
                </div>
              </td>
              <td>
                <div colspan="1" style="width: 121px; box-sizing: border-box;" class="desc text-center"
                  @click="OpenPopupTrain(item)">
                  Xem chi tiết
                </div>
              </td>
              <td>
                <div colspan="1" style="width: 121px; box-sizing: border-box;" class="desc text-center"
                  @click="OpenPopupFostering(item)">
                  Xem chi tiết
                </div>
              </td>
            </div>

            <!-- <td
                ref="func"
                class="td-item-final td-func sticky-right"
                style="right: 0; background-color: #fff; width: auto;"
                colspan="12"
              >
                <button class="bonus"  @click="OpenPopupEducation(item)">
                 Trình độ học vấn
                </button>
                <button class="dis" @click="OpenPopupTrain(item)">
                  Quá trình đào tạo
                </button>
                <button class="dis" @click="OpenPopupFostering(item)">
                  Quá trình bồi dưỡng
                </button>
              </td>  -->

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
              <div class="item-dropup" :class="{ act: isActive == '10' }" pageSize="10" :value="pageDefault"
                @click="getPageDefault">
                10 bản ghi trên 1 trang
              </div>
              <div class="item-dropup" :class="{ act: isActive == '20' }" pageSize="20" @click="getPageDefault">
                20 bản ghi trên 1 trang
              </div>
              <div class="item-dropup" :class="{ act: isActive == '30' }" pageSize="30" @click="getPageDefault">
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
          <Paginate v-model="pageNumber" :page-count="totalPage" :page-range="3" :margin-pages="1"
            :click-handler="clickCallback" :prev-text="'Trước'" :next-text="'Sau'" :container-class="'pagination'"
            :page-class="'page-item'">
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
import axios from "axios"
import $ from "jquery"
import Paginate from "vuejs-paginate-next";
import { useToast } from "vue-toastification";
import popUp from "../base/BasePopupDelete2.vue"
import Notifi from "../base/FormNotifi.vue"
export default {
  data() {
    return {
      isOpenPopupTrain: false,
      isOpenPopupFostering: false,
      isOpenPopupEducation: false,
      isOpenPopupFormAddEducation: false,
      isOpenPopupFormEditEducation: false,
      isOpenPopupFormAddTrain: false,
      isOpenPopupFormEditTrain: false,
      isOpenPopupFormAddFostering: false,
      isOpenPopupFormEditFostering: false,
      pageDefault: 10,
      pageNumber: 1,
      txtSearch: "",
      totalPage: 1,
      totalRecord: 0,
      students: {},
      suaHocVan: {},
      suaDaotao: {},
      suaBoiDuong: {},
      hocvan: {},
      daotao: {},
      boiduong: {},
      isShowPopupEdu: false,
      isShowPopupFos: false,
      isShowPopupTrain: false,
      IDNV: "",
      MaNV: "",
      TenNV: "",
      isShowDrop: false,
      mess: "",
      dataSinhVienPunish: [],
      dataSinhVienBonus: {},
      isShowNotifi: false,
      isShowEditTrain: false,
      isShowAddTrain: false,
      isShowEditEdu: false,
      isShowAddFos: false,
      isShowEditFos: false,
      isShowLoad: false,
      idDelete: "",
      errors: {
        quanligiaoduc: '',
        tinhtranghocvan: '',
        chungchingoaingu: '',
        chuyennganhdaotao: '',
        hinhthuc: '',
        bangcap: '',
        coso: '',
        vanbangchungchi: '',
        noidungboiduong: '',
        noiboiduong: '',
        hinhthucdaotao:''

      }
    }
  },

  components: {
    Paginate, popUp, Notifi
  },
  watch: {
    txtSearch: function () {
      if (this.txtSearch == "") {
        this.getPagingEmployee();
      }
    }

  },
  created() {
    this.getPagingEmployee()
  },
  methods: {
    SavePunish() {
      var me = this
      const toast = useToast();
      try {

        axios
          .post(
            "https://localhost:44301/api/Discipline", this.dataSinhVienPunish
          )
          .then(function (res) {
            console.log(res)
            toast.success("thêm dữ liệu thành công", { timeout: 2000 });
            me.isOpenPopupEducation = false
          })
          .catch(function () {
            console.log("error");
            toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }
    },
    SaveBonus() {
      var me = this
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
            me.isOpenPopupTrain()
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
    cancelForm() {
      this.isShowNotifi = false;
      this.isOpenPopupFormAddEducation = false
    },
    cancelFormEditEdu(value) {
      this.isShowEditEdu = value;
      this.isOpenPopupFormEditEducation = false;
    },
    cancelFormAddTrain(value) {
      this.isShowAddTrain = value;
      this.isOpenPopupFormAddTrain = false;
    },
    cancelFormEditTrain(value) {
      this.isShowEditTrain = value;
      this.isOpenPopupFormEditTrain = false;
    },
    cancelFormAddFos(value) {
      this.isShowAddFos = value;
      this.isOpenPopupFormAddFostering = false;
    },
    cancelFormEditFos(value) {
      this.isShowEditFos = value;
      this.isOpenPopupFormEditFostering = false;
    },
    closeNo(value) {
      this.isShowNotifi = value;
      this.isShowAddFos = value;
      this.isShowEditFos = value;
      this.isShowEditTrain = value;
      this.isShowAddTrain = value;
      this.isShowEditEdu = value;
    },
    hideFormAddEdu() {
      this.isShowNotifi = !this.isShowNotifi;
    },
    hideFormEditEdu() {
      this.isShowNotifi = true;
    },

    getTrain() {
      try {

        var me = this;

        axios
          .get(
            `https://localhost:44301/api/daotao/${this.IDNV}`
          )
          .then(function (res) {
            me.daotao = res.data

          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupTrain(item) {
      this.isOpenPopupTrain = true;
      this.IDNV = item.IDNhanVien
      this.MaNV = item.MaNV
      this.TenNV = item.TenNV
      this.getTrain()

    },
    getFos() {
      try {

        var me = this;

        axios
          .get(
            `https://localhost:44301/api/boiduong/${this.IDNV}`
          )
          .then(function (res) {
            me.boiduong = res.data
            console.log(me.boiduong);
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
      this.IDNV = item.IDNhanVien
      this.MaNV = item.MaNV
      this.TenNV = item.TenNV
      this.getFos()
    },
    OpenPopupEducation(item) {
      this.isOpenPopupEducation = true;
      this.IDNV = item.IDNhanVien
      this.MaNV = item.MaNV
      this.TenNV = item.TenNV
      this.getEdu()
    },
    getEdu() {
      try {

        var me = this;

        axios
          .get(
            `https://localhost:44301/api/hocvan/${this.IDNV}`
          )
          .then(function (res) {
            me.hocvan = res.data
          })

          .catch(function () {
            console.log(1);
          });
      } catch (error) {
        console.log(error);
      }
    },
    OpenPopupFormAddEducation() {
      this.isOpenPopupFormAddEducation = true;
      this.suaHocVan = {},
        this.suaHocVan.IDNhanVien = this.IDNV
    },

    btnAddEducation() {
      var me = this
      const toast = useToast();
      me.suaHocVan.IDNhanVien = me.IDNV
      console.log(me.suaHocVan);
      this.validateCCNN()
      this.validateQLGD()
      this.validateTTHV()
      if (this.isValid == true) {
        try {

          axios
            .post(
              "https://localhost:44301/api/hocvan", this.suaHocVan
            )
            .then(function (res) {
              console.log(res)
              me.isOpenPopupFormAddEducation = false;
              toast.success("thêm dữ liệu thành công", { timeout: 2000 });
              me.getEdu()

            })
            .catch(function () {
              console.log("error");
              toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
            });
        } catch (error) {
          console.log(error);
        }
      }
    },
    // saveEducation() {
    //   this.validateQLGD()
    //   this.validateTTHV()
    //   this.validateCCNN()
    //   if (this.isValid == true) {
    //     if (this.formMode == 1) {
    //       this.btnAddEducation()
    //     }
    //     else {
    //       this.editEducation()
    //     }
    //   }
    // },
    OpenPopupFormEditEducation(item) {
      this.isOpenPopupFormEditEducation = true;
      console.log(item);
      this.suaHocVan = item
    },
    editEducation() {
      var me = this
      const toast = useToast();
      me.suaHocVan.IDNhanVien = me.IDNV
      console.log(me.suaHocVan);
      try {

        axios
          .put(
            `https://localhost:44301/api/hocvan/${this.suaHocVan.IDHocVan}`, this.suaHocVan
          )
          .then(function (res) {
            console.log(res)
            me.isOpenPopupFormEditEducation = false;
            toast.success("sửa dữ liệu thành công", { timeout: 2000 });
            me.getEdu()

          })
          .catch(function () {
            console.log("error");
            toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
          });
      } catch (error) {
        console.log(error);
      }

    },
    showAddEducation() {
      this.isOpenPopupFormAddEducation = false
      this.suaHocVan = {},
        this.errors.chungchingoaingu = "";
      this.errors.tinhtranghocvan = "";
      this.errors.quanligiaoduc = "";
      this.getEdu();
    },
    showAddTrain() {
      this.isOpenPopupFormAddTrain = false
      this.suaDaotao = {},
        this.errors.chuyennganhdaotao = "";
      this.errors.hinhthucdaotao = "";
      this.errors.bangcap = "";
      this.getTrain()
    },
    showAddFos() {
      this.isOpenPopupFormAddFostering = false
      this.suaBoiDuong = {}
      this.errors.vanbangchungchi = "";
      this.errors.noiboiduong = "";
      this.errors.noidungboiduong = "";
      this.getFos()
    },
    deleteEducation(item) {
      this.idDelete = ""
      console.log(item.IDHocVan);
      this.isShowPopupEdu = true
      this.idDelete = item.IDHocVan
      this.mess = "Bạn có chắc chắn muốn xóa thông tin học vấn này không?"

    },
    noDelete(value) {
      this.isShowPopupEdu = value
      this.isShowPopupTrain = value
      this.isShowPopupFos = value
    },
    deleteOK(value) {
      this.isShowPopupEdu = value
      var me = this
      const toast = useToast();
      try {
        axios
          .delete(
            `https://localhost:44301/api/hocvan/${this.idDelete}`
          )
          .then(function (res) {
            console.log(res);
            toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
            me.getEdu()
          })

          .catch(function () {
            toast.error("xóa dữ liệu thất bại", { timeout: 2000 });

          });
      } catch (error) {
        console.log(error);
      }
    },

    OpenPopupFormAddTrain() {
      this.isOpenPopupFormAddTrain = true;
      this.suaDaotao = {}
      this.suaDaotao.IDNhanVien = this.IDNV
      // this.dataSinhVienPunish = item
    },
    btnAddTraning() {

      var me = this
      const toast = useToast();
      me.suaDaotao.IDNhanVien = me.IDNV
      this.validateCNDT()
      this.validateHinhThuc()
      this.validateBangCap()
      if (this.isValid == true) {

        try {

          axios
            .post(
              "https://localhost:44301/api/daotao", this.suaDaotao
            )
            .then(function (res) {
              console.log(res)
              toast.success("thêm dữ liệu thành công", { timeout: 2000 });
              me.isOpenPopupFormAddTrain = false;
              me.getTrain()
            })
            .catch(function () {
              console.log("error");
              toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
            });
        } catch (error) {
          console.log(error);
        }
      }
    },
    // saveTraning() {
    //   this.validateCNDT()
    //   this.validateHinhThuc()
    //   this.validateBangCap()
    //   if (this.isValid == true) {

    //       this.btnAddTraning()
    //     }
    //     else {
    //       this.editTrain()
    //     }
    //   }
    // },
    OpenPopupFormEditTrain(item) {
      this.isOpenPopupFormEditTrain = true;
      this.suaDaotao = item
      item.ThoiGianBatDau = this.formatDate(item.ThoiGianBatDau)
      this.suaDaotao.ThoiGianBatDau = item.ThoiGianBatDau
      item.ThoiGianKetThuc = this.formatDate(item.ThoiGianKetThuc)
      this.suaDaotao.ThoiGianKetThuc = item.ThoiGianKetThuc
    },
    editTrain() {

      var me = this
      const toast = useToast();
      me.suaDaotao.IDNhanVien = me.IDNV
      this.validateCNDT()
      this.validateHinhThuc()
      this.validateBangCap()
      if (this.isValid == true) {


        try {

          axios
            .put(
              `https://localhost:44301/api/daotao/${this.suaDaotao.IDDaoTao}`, this.suaDaotao
            )
            .then(function (res) {
              console.log(res)
              toast.success("sửa dữ liệu thành công", { timeout: 2000 });
              me.isOpenPopupFormEditTrain = false;
              me.getTrain()
            })
            .catch(function () {
              console.log("error");
              toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
            });
        } catch (error) {
          console.log(error);
        }
      }
    },
    deleteTrain(item) {
      this.idDelete = ""
      this.isShowPopupTrain = true
      this.idDelete = item.IDDaoTao
      this.mess = "Bạn có chắc chắn muốn xóa thông tin đào tạo này không?"
    },
    deleteTrainOK(value) {
      this.isShowPopupTrain = value
      var me = this
      const toast = useToast();
      try {
        axios
          .delete(
            `https://localhost:44301/api/daotao/${this.idDelete}`
          )
          .then(function (res) {
            console.log(res);
            toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
            me.getTrain()
          })

          .catch(function () {
            toast.error("xóa dữ liệu thất bại", { timeout: 2000 });

          });
      } catch (error) {
        console.log(error);
      }
    },

    OpenPopupFormAddFostering() {
      this.isOpenPopupFormAddFostering = true;
      this.suaBoiDuong = {},
        this.suaBoiDuong.IDNhanVien = this.IDNV
    },

    btnAddFos() {
      var me = this
      const toast = useToast();

      me.suaBoiDuong.IDNhanVien = me.IDNV
      this.validateNDBD()
      this.validateNoiBD()
      this.validateVBCC()
      if (this.isValid == true) {
        try {

          axios
            .post(
              "https://localhost:44301/api/boiduong", this.suaBoiDuong
            )
            .then(function (res) {
              console.log(res)
              toast.success("thêm dữ liệu thành công", { timeout: 2000 });
              me.isOpenPopupFormAddFostering = false;
              me.getFos()
            })
            .catch(function () {
              console.log("error");
              toast.error("thêm dữ liệu thất bại", { timeout: 2000 });
            });
        } catch (error) {
          console.log(error);
        }
      }
    },
    saveFos() {
      this.validateNDBD()
      this.validateNoiBD()
      this.validateVBCC()
      if (this.isValid == true) {
        if (this.formMode == 1) {
          this.btnAddFos()
        }
        else {
          this.btnEditFos()
        }
      }
    },
    OpenPopupFormEditFostering(item) {
      this.isOpenPopupFormEditFostering = true;
      this.suaBoiDuong = item
      item.ThoiGianBatDau = this.formatDate(item.ThoiGianBatDau)
      this.suaBoiDuong.ThoiGianBatDau = item.ThoiGianBatDau
      item.ThoiGianKetThuc = this.formatDate(item.ThoiGianKetThuc)
      this.suaBoiDuong.ThoiGianKetThuc = item.ThoiGianKetThuc
    },
    btnEditFos() {
      var me = this
      const toast = useToast();
      me.suaBoiDuong.IDNhanVien = me.IDNV
      this.validateNDBD()
      this.validateNoiBD()
      this.validateVBCC()
      if (this.isValid == true) {
        try {

          axios
            .put(
              `https://localhost:44301/api/boiduong/${this.suaBoiDuong.IDBoiDuong}`, this.suaBoiDuong
            )
            .then(function (res) {
              console.log(res)
              toast.success("sửa dữ liệu thành công", { timeout: 2000 });
              me.isOpenPopupFormEditFostering = false;
              me.getFos()
            })
            .catch(function () {
              console.log("error");
              toast.error("sửa dữ liệu thất bại", { timeout: 2000 });
            });
        } catch (error) {
          console.log(error);
        }
      }
    },
    deleteFos(item) {
      this.idDelete = ""
      this.isShowPopupFos = true
      this.idDelete = item.IDBoiDuong
      this.mess = "Bạn có chắc chắn muốn xóa thông tin bồi dưỡng này không?"
    },
    deleteFosOK(value) {
      this.isShowPopupFos = value
      var me = this
      const toast = useToast();
      try {
        axios
          .delete(
            `https://localhost:44301/api/boiduong/${this.idDelete}`
          )
          .then(function (res) {
            console.log(res);
            toast.success("Xóa dữ liệu thành công", { timeout: 2000 });
            me.getFos()
          })

          .catch(function () {
            toast.error("xóa dữ liệu thất bại", { timeout: 2000 });

          });
      } catch (error) {
        console.log(error);
      }
    },
    getPagingEmployee() {
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
      this.getPagingEmployee();
      if (this.pageDefault > this.totalRecord) {
        this.pageDefault = this.totalRecord;
      }
    },

    clickCallback(pageNum) {
      this.pageNumber = pageNum;
      this.getPagingEmployee();
    },
    // validate
    validateQLGD() {
      if (!this.suaHocVan.TrinhDoQLGD) {
        this.errors.quanligiaoduc = "Trình quản lý giáo dục không được để trống!";
        this.isValid = false;
      }
      else {
        this.errors.quanligiaoduc = "";
        this.isValid = true;
      }
    },
    validateTTHV() {

      if (!this.suaHocVan.TinhTrangHocVan) {
        this.errors.tinhtranghocvan = "Tình trạng học vấn không được để trống!";
        this.isValid = false;
      }
      else {
        this.errors.tinhtranghocvan = "";
        this.isValid = true;
      }
    },
    validateCCNN() {
      if (!this.suaHocVan.ChungChiNgoaiNgu) {
        this.errors.chungchingoaingu = "Chứng chỉ ngoại ngữ không được để trống!";
        this.isValid = false;
      }
      else {
        this.errors.chungchingoaingu = "";
        this.isValid = true;
      }
    },
    validateCNDT() {
      if (!this.suaDaotao.ChuyenNganh) {
        this.errors.chuyennganhdaotao = "Chuyên ngành đào tạo không được để trống!";
        this.isValid = false;
      }
      else {
        this.errors.chuyennganhdaotao = "";
        this.isValid = true;
      }
    },
    validateHinhThuc() {
      if (!this.suaDaotao.HinhThucDaoTao) {
        this.errors.hinhthucdaotao = "Hình thức đào tạo không được để trống!";
        this.isValid = false;
      }
      else {
        this.errors.hinhthucdaotao = "";
        this.isValid = true;
      }
    },
    validateBangCap() {
      if (!this.suaDaotao.BangCap) {
        this.errors.bangcap = "Bằng cấp không được để trống!";
        this.isValid = false;
      }
      else {
        this.errors.bangcap = "";
        this.isValid = true;
      }
    },
    validateNDBD() {
      if (!this.suaBoiDuong.NoiDungBoiDuong) {
        this.errors.noidungboiduong = "Nội dung bồi dưỡng không được để trống!";
        this.isValid = false;
      }
      else {
        this.errors.noidungboiduong = "";
        this.isValid = true;
      }
    },
    validateNoiBD() {
      if (!this.suaBoiDuong.DiaDiem) {
        this.errors.noiboiduong = "Nơi bồi dưỡng không được để trống!";
        this.isValid = false;
      }
      else {
        this.errors.noiboiduong = "";
        this.isValid = true;
      }
    },
    validateVBCC() {
      if (!this.suaBoiDuong.VanBangChungChi) {
        this.errors.vanbangchungchi = "Văn bằng chứng chỉ không được để trống!";
        this.isValid = false;
      }
      else {
        this.errors.vanbangchungchi = "";
        this.isValid = true;
      }
    },
  },

};
</script>
<style scoped>
.invalid-feedback {
  color: red;
  position: absolute;
  font-size: 12px;
  margin-top: 36px;
  margin-left: 200px;
}

.border-red {
  border-color: red
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
  width: 67px;
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
  color: #7EA1F9;
  background-color: #fff;
}

.column input {
  width: 80%;
}

.input__box {
  display: flex;
  justify-content: space-between;
  margin-bottom: 20px;
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
  color: #7EA1F9;
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
  z-index: 2;
  /* position: fixed;
    display: flex; */
  cursor: pointer;
  /* height: 600px; */
}

.action-form {
  padding: 0px 20px;
  position: absolute;
  width: 68vw;
  height: 590px;
  top: 10%;
  right: 14%;
  z-index: 99999;
  border-radius: 20px;
  box-shadow: 5px 5px 5px;
  background-color: #fff;

}

.bonus-form {
  padding: 0px 20px;
  position: absolute;
  width: 68vw;
  height: 590px;
  top: 10%;
  right: 14%;
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
  color: #000;
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
  color: #5d82e0;
  position: absolute;
  right: 150px;
  border: 1px solid #5d82e0;
  bottom: 20px;
  padding: 4px;
  min-width: 67px;
  border-radius: 5px;
  text-align: center;
}

.btnCancel:hover {
  background-color: #5d82e0;
  color: #fff;
}
</style>
  