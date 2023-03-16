<template>
     <div id="form">
        <div class="form">
            <div class="form-top">
                <div class="form-title">
                    <h3 class="title">Thêm/sửa thông tin sinh viên</h3>
                    <span class="close" @click="closeForm">X</span>
                </div>
            </div>
            <div class="form-Wrap">
                <div class="column">
                    <div class="input__box">
                        <label for="">Mã sinh viên</label>
                        <input type="text">
                    </div>
                    <div class="input__box">
                        <label for="">Tên sinh viên</label>
                        <input type="text">
                    </div>
                    <div class="input__box">
                        <label for="">Giới tính</label>
                        <div class="radio__box">
                            <input type="radio" id="nam" v-model="desc.gioitinh" value="nam">
                            <label class="nam" for="">Nam</label>
                            <input type="radio" id="nu" v-model="desc.gioitinh" value="nu">
                            <label class="nu" for="">Nữ</label>
                        </div>
                        <!-- <div style= "color:red" id="disp">{{ desc.gioitinh }}</div> -->
                    </div>
                </div>
                
                <div class="column">
                    <div class="input__box">
                        <label for="">Ngày sinh</label>
                        <input type="text">
                    </div>
                    <div class="input__box">
                        <label for="">Khoa</label>
                        <input @blur="validate()" class="khoa" type="text" v-model="desc.khoa">
                        <div class="invalid-feedback" v-if="errors.khoa">{{ errors.khoa }}</div>
                    </div>
                </div>
                <div class="column">
                    <div class="input__box">
                        <label for="">Cmnd/cccd</label>
                        <input type="text">
                    </div>
                    <div class="input__box">
                        <label for="">Ngày cấp</label>
                        <input type="text">
                    </div>
                </div>
                <div class="input__box">    
                    <label for="">Nơi cấp</label>
                    <input @blur="validate()" class="noicap" type="text" v-model="desc.noicap">
                        <div class="invalid-feedback" v-if="errors.noicap">{{ errors.noicap }}</div>
                </div>
                <div class="column">
                    <div class="input__box">
                        <label for="">Email</label>
                        <input type="text">
                    </div>
                    <div class="input__box">
                        <label for="">Số điện thoại</label>
                        <input type="text">
                    </div>
                </div>
                <div class="input__box">    
                    <label for="">Địa chỉ</label>
                    <input @blur="validate()" class="diachi" type="date" v-model="desc.diachi">
                    <div class="invalid-feedback" v-if="errors.diachi">{{ errors.diachi }}</div>
                </div>
                <div class="column column-s">
                    <div class="input__box">
                        <label for="">Chương trình đào tạo</label>
                        <input type="text">
                    </div>
                    <div class="input__box">
                        <label for="">Ngày nhập học</label>
                        <input type="text">
                    </div>
                    <div class="input__box">
                        <label for="">Ngày dự kiến tốt nghiệp</label>
                        <input type="text">
                    </div>

                </div>
            </div>
            <div class="form-bottom">
                <div class="btn btn-cancel">Hủy</div>
                <div class="btn btn-save" @click="save()">Lưu</div>
            </div>
        </div>
    </div>
</template>
<style>
.invalid-feedback {
    color: red;
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
  input {
    max-width: 100%;
    max-height: 20px;
    padding-bottom: 6px;
    border: 1px solid #ccc;
    border-radius: 2px;
    outline: none;
    height: 29px;
    position: relative;
    height: 29px;
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
    width:800px;
    /* display: none; */
}
    .form-Wrap {
        padding: 0 20px;
    }
    .form-title {
        padding: 0 13px;
        background-color: #D9D9D9;
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
    margin-bottom: 10px;
  }
  .form-bottom {
    display: flex;
    justify-content: flex-end;
    padding: 14px;
    background-color: #D9D9D9;
    gap: 28px;
    margin-top: 14px;
  }
  .btn-cancel {
    background-color: #fff;
  }
  .btn-save {
    background-color:  #1A8FDD;
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
    margin-top: 8px;
    column-gap: 10px;
  }
  .radio__box input {
    width: 15px;
    margin: 0;
  }
  
</style>
<script>
    export default {
        data(){
            return {
                errors: {
                    masv: '',
                    ten: '',
                    ngaysinh: '',
                    khoa: '',
                    cmnd: '',
                    ngaycap: '',
                    noicap: '',
                    email: '',
                    sodt: '',
                    diachi: '',
                    daotao: '',
                    ngaynhaphoc: '',
                    ngaytotnghiep: '',
                },
                desc: {
                    masv: '',
                    ten: '',
                    ngaysinh: '',
                    khoa: '',
                    cmnd: '',
                    ngaycap: '',
                    noicap: '',
                    email: '',
                    sodt: '',
                    diachi: '',
                    daotao: '',
                    ngaynhaphoc: '',
                    ngaytotnghiep: '',
                }
            }
        },
        methods: {
            validate(){
                let isValid = true;

                this.errors = {
                    masv: '',
                    ten: '',
                    ngaysinh: '',
                    khoa: '',
                    cmnd: '',
                    ngaycap: '',
                    noicap: '',
                    email: '',
                    sodt: '',
                    diachi: '',
                    daotao: '',
                    ngaynhaphoc: '',
                    ngaytotnghiep: '',
                }
                if(!this.desc.masv) {
                    this.errors.masv = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.ten) {
                    this.errors.ten = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.ngaysinh) {
                    this.errors.ngaysinh = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.sodt) {
                    this.errors.sodt = "Không được để trống!";
                    isValid = false;
                } else if(!this.isNumber(this.desc.sodt)) {
                    this.errors.sodt = "Yêu cầu nhập số";
                    isValid = false;
                }
                if(!this.desc.khoa) {
                    this.errors.khoa = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.cmnd) {
                    this.errors.cmnd = "Không được để trống!";
                    isValid = false;
                }else if(!this.isNumber(this.desc.cmnd)) {
                    this.errors.cmnd = "Yêu cầu nhập số";
                    isValid = false;
                }
                if(!this.desc.ngaycap) {
                    this.errors.ngaycap = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.noicap) {
                    this.errors.noicap = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.email) {
                    this.errors.email = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.diachi) {
                    this.errors.diachi = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.daotao) {
                    this.errors.daotao = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.ngaynhaphoc) {
                    this.errors.ngaynhaphoc = "Không được để trống!";
                    isValid = false;
                }
                if(!this.desc.ngaytotnghiep) {
                    this.errors.ngaytotnghiep = "Không được để trống!";
                    isValid = false;
                }
                return isValid
            },
            isNumber(value) {
                return /^\d*$/.test(value);
            },
            save(){
                this.validate()
                console.log(this.validate())
            },
            // onclick(){
            //     this.save();
            // }
        },
        created() {
            // this.save()
            //gọi chỗ này là khi mở lên nó gọi hàm kia luôn k cần click gì
        }
    }
</script>