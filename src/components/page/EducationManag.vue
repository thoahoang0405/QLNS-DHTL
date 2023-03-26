<template>
  <!-- hoc van -->
    <div class="body">
      <div class="popup-bonus" v-if="isOpenPopupEducation">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Trình độ học vấn</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupEducation = false">
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
            <div class="maNV">Mã nhân viên: abc</div>
            <div class="tenNV">Tên nhân viên: Ngô Văn Tùng</div>
            <div class="btnWrap">
              <div class="btnAdd" @click="OpenPopupFormAddEducation(item)">Thêm</div>
              <!-- <div class="btnEdit">Sửa</div> -->
            </div>
          </div>
          <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
            <tr>
              <th>Trình độ lý luận chính trị</th>
              <th>Trình quản lý giáo dục</th>
              <th>Trình độ tin học</th>
              <th>Chứng chỉ ngoại ngữ</th>
              <th>Tình trạng học vấn</th>
              <th style="width: 60px;">Chức năng</th>
            </tr>
            <tr>
            </tr>
            <tr>
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
                <div class="icon icon-edit" @click="OpenPopupFormEditEducation(item)"></div>
                <div class="icon icon-delete"></div>
              </td>
            </tr>
          </table>
        </div>
      </div>
      <!-- them hoc van -->
      <div class="popup-bonus" v-if="isOpenPopupFormAddEducation">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Thêm trình độ học vấn</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupFormAddEducation = false">
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
          
          <div style="display: flex; font-weight: 600; margin: 20px 0;">
            <div class="maNV" style="padding-right: 40px;">Mã nhân viên: abc</div>
            <div class="tenNV">Tên nhân viên: Ngô Văn Tùng</div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Trình độ chính trị: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Trình quản lý giáo dục: </label>
              <input type="text">
           </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Trình độ tin học: </label>
              <input type="text">
            </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Chứng chỉ ngoại ngữ: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Tình trạng học vấn: </label>
              <input type="text">
            </div>
          </div>
          <div class="btnCancel" @click.stop="isOpenPopupFormAddEducation = false">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
      </div>
      <!-- sua hoc van-->
      <div class="popup-bonus" v-if="isOpenPopupFormEditEducation">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Sửa trình độ học vấn</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupFormEditEducation = false">
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
          <div style="display: flex; font-weight: 600; margin: 20px 0;">
            <div class="maNV" style="padding-right: 40px;">Mã nhân viên: abc</div>
            <div class="tenNV">Tên nhân viên: Ngô Văn Tùng</div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Trình độ chính trị: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Trình quản lý giáo dục: </label>
              <input type="text">
           </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Trình độ tin học: </label>
              <input type="text">
            </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Chứng chỉ ngoại ngữ: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Tình trạng học vấn: </label>
              <input type="text">
            </div>
          </div>
          <div class="btnCancel" @click.stop="isOpenPopupFormEditEducation = false">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
      </div>
      <!-- end open popup hoc van   -->

      <!-- dao tao -->
      <div class="popup-bonus" v-if="isOpenPopupTrain">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Quá trình đào tạo</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupTrain = false">
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
            <div class="maNV">Mã nhân viên: abc</div>
            <div class="tenNV">Tên nhân viên: Ngô Văn Tùng</div>
            <div class="btnWrap">
              <div class="btnAdd" @click="OpenPopupFormAddTrain(item)">Thêm</div>
              <!-- <div class="btnEdit">Sửa</div> -->
            </div>
          </div>
          <table style="width: 100%; border-collapse: collapse; border: 1px solid; margin-top: 12px;">
            <tr>
              <th>Thời gian bắt đầu</th>
              <th>Thời gian  kết thúc</th>
              <th>Nơi đào tạo</th>
              <th>Chuyên ngành</th>
              <th>Hình thức đào tạo</th>
              <th>Bằng cấp</th>
              <th style="width: 60px;">Chức năng</th>
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
                <div class="icon icon-edit" @click="OpenPopupFormEditTrain(item)"></div>
                <div class="icon icon-delete"></div>
              </td>
            </tr>
          </table>
          
        </div>
      </div>
      <!-- them dao tao -->
      <div class="popup-bonus" v-if="isOpenPopupFormAddTrain">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Thêm quá trình đào tạo</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupFormAddTrain = false">
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
          
          <div style="display: flex; font-weight: 600; margin: 20px 0;">
            <div class="maNV" style="padding-right: 40px;">Mã nhân viên: abc</div>
            <div class="tenNV">Tên nhân viên: Ngô Văn Tùng</div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Thời gian bắt đầu: </label>
              <input type="date">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Thời gian kết thúc: </label>
              <input type="date">
           </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Nơi đào tạo: </label>
              <input type="text">
            </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Chuyên ngành: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Hình thức đào tạo: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Học vấn: </label>
              <input type="text">
            </div>
          </div>
          <div class="btnCancel" @click.stop="isOpenPopupFormAddTrain = false">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
      </div>
      <!-- sua dao tao-->
      <div class="popup-bonus" v-if="isOpenPopupFormEditTrain">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Sửa quá trình đào tạo</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupFormEditTrain = false">
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
          <div style="display: flex; font-weight: 600; margin: 20px 0;">
            <div class="maNV" style="padding-right: 40px;">Mã nhân viên: abc</div>
            <div class="tenNV">Tên nhân viên: Ngô Văn Tùng</div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Thời gian bắt đầu: </label>
              <input type="date">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Thời gian kết thúc: </label>
              <input type="date">
           </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Nơi đào tạo: </label>
              <input type="text">
            </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Chuyên ngành: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Hình thức đào tạo: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Học vấn: </label>
              <input type="text">
            </div>
          </div>
          <div class="btnCancel" @click.stop="isOpenPopupFormEditTrain = false">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
      </div>
      <!-- end dao tao -->

      <!-- boi duong -->
      <div class="popup-bonus" v-if="isOpenPopupFostering">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Quá trình bồi dưỡng</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupFostering = false">
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
            <div class="maNV">Mã nhân viên: abc</div>
            <div class="tenNV">Tên nhân viên: Ngô Văn Tùng</div>
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
              <th style="width: 60px;">Chức năng</th>
            </tr>
            <tr>
            </tr>
            <tr>
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
                <div class="icon icon-edit" @click="OpenPopupFormEditFostering(item)"></div>
                <div class="icon icon-delete"></div>
              </td>
            </tr>
          </table>
        </div>
      </div>
      <!-- them boi duong -->
      <div class="popup-bonus" v-if="isOpenPopupFormAddFostering">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Thêm quá trình bồi dưỡng</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupFormAddFostering = false">
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
          
          <div style="display: flex; font-weight: 600; margin: 20px 0;">
            <div class="maNV" style="padding-right: 40px;">Mã nhân viên: abc</div>
            <div class="tenNV">Tên nhân viên: Ngô Văn Tùng</div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Thời gian bắt đầu: </label>
              <input type="date">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Thời gian kết thúc: </label>
              <input type="date">
           </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Nội dung: </label>
              <input type="text">
            </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Nơi bồi dưỡng: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Bằng cấp: </label>
              <input type="text">
            </div>
          </div>
          <div class="btnCancel" @click.stop="isOpenPopupFormAddFostering = false">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
      </div>
      <!-- sua boi duong-->
      <div class="popup-bonus" v-if="isOpenPopupFormEditFostering">
        <div class="bonus-form">
          <div class="head-popup">
            <h3 class="title-heading">Sửa quá trình bồi dưỡng</h3>
            <div class="btn-close-popup" @click.stop="isOpenPopupFormEditFostering = false">
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
          <div style="display: flex; font-weight: 600; margin: 20px 0;">
            <div class="maNV" style="padding-right: 40px;">Mã nhân viên: abc</div>
            <div class="tenNV">Tên nhân viên: Ngô Văn Tùng</div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Thời gian bắt đầu: </label>
              <input type="date">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Thời gian kết thúc: </label>
              <input type="date">
           </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Nội dung: </label>
              <input type="text">
            </div>
          </div> 
          <div class="column">
            <div class="input__box">
              <label for="">Nơi bồi dưỡng: </label>
              <input type="text">
            </div>
          </div>
          <div class="column">
            <div class="input__box">
              <label for="">Bằng cấp: </label>
              <input type="text">
            </div>
          </div>
          <div class="btnCancel" @click.stop="isOpenPopupFormEditFostering = false">Hủy</div>
          <div class="btnSave">Lưu</div>
        </div>
      </div>
      <!--end boi duong  -->

      <h3 class="header-bd">Đào tạo</h3>
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
              <th>Trình độ học vấn</th>
              <th>Quá trình đào tạo</th>
              <th>Quá trình bồi dưỡng</th>
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
              <td>{{ item.StudentCode }}</td>
              <td>{{ item.StudentName }}</td>
              <td>{{ item.DateOfBirth }}</td>
              <td>{{ item.Gender }}</td>
              <td></td>
              <!-- <td>{{ item.FacultyName }}</td> -->
              <!-- <td>{{ item.Class }}</td> -->
              <!-- <td>{{ item.ClassifiOpenPopupBonuscationName }}</td> -->
              <td>
                <div class="desc"  @click="OpenPopupEducation(item)">
                  Xem chi tiết
                </div>
              </td>
              <td>
                <div class="desc" @click="OpenPopupTrain(item)">
                  Xem chi tiết
                </div>
              </td>
              <td>
                <div class="desc" @click="OpenPopupFostering(item)">
                  Xem chi tiết
                </div>
              </td>
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
        isOpenPopupTrain: false,
        isOpenPopupFostering: false,
        isOpenPopupEducation: false,
        isOpenPopupFormAddEducation: false,
        isOpenPopupFormEditEducation: false,
        isOpenPopupFormAddTrain: false,
        isOpenPopupFormEditTrain: false,
        isOpenPopupFormAddFostering: false,
        isOpenPopupFormEditFostering: false,
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
              "https://localhost:7029/api/Discipline",this.dataSinhVienPunish
            )
            .then(function (res) {
              console.log(res)
              toast.success("thêm dữ liệu thành công", { timeout: 2000 });
              me.isOpenPopupEducation=false
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
              "https://localhost:7029/api/Bonus",
              
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
      OpenPopupTrain(item) {
        this.isOpenPopupTrain = true;
        this.dataSinhVienBonus = item
      },
      OpenPopupFostering(item) {
        this.isOpenPopupFostering = true;
        this.dataSinhVienBonus = item
      },
      OpenPopupEducation(item) {
        this.isOpenPopupEducation = true;
        this.dataSinhVienPunish = item
      },
      OpenPopupFormAddEducation(item) {
        this.isOpenPopupFormAddEducation = true;
        this.dataSinhVienPunish = item
      },
      OpenPopupFormEditEducation(item) {
        this.isOpenPopupFormEditEducation = true;
        this.dataSinhVienPunish = item
      },
      OpenPopupFormAddTrain(item) {
        this.isOpenPopupFormAddTrain = true;
        this.dataSinhVienPunish = item
      },
      OpenPopupFormEditTrain(item) {
        this.isOpenPopupFormEditTrain = true;
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
      getpagingStudent() {
      try {
       
        var me = this;
       
        axios
          .get(
            `https://localhost:7029/api/Students/Filter?keyword=${this.txtSearch}&pageSize=${this.pageDefault}&facultyID=${this.facultyID}&classificationID=${this.classificationID}&pageNumber=${this.pageNumber}`
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
    width: 85px;
    border: 1px solid;
    text-align: center;
    padding: 5px;
    border-radius: 5px;
    color: #fff;
    background-color: #7EA1F9;
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
    /* height: 600px; */
  }
  .bonus-form {
    padding: 0px 20px;
    position: absolute;
    width: 70vw;
    height: 590px;
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
  </style>
  