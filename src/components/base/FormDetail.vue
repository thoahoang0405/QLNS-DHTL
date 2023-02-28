<template>
     <div id="form">
        <div class="form">
            <div class="form-top">
                <div class="form-title">
                    <h3 class="title">Thêm/sửa thông tin sinh viên</h3>
                    <span class="close">X</span>
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
                            <input type="radio" name="gt">
                            <label for="">Nam</label>
                            <input type="radio" name="gt">
                            <label for="">Nữ</label>
                        </div>
                    </div>
                </div>
                
                <div class="column">
                    <div class="input__box">
                        <label for="">Ngày sinh</label>
                        <input type="text">
                    </div>
                    <div class="input__box">
                        <label for="">Khoa</label>
                        <input type="text">
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
                    <input type="text">
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
                    <input type="text">
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
                <div class="btn btn-save">Lưu</div>
            </div>
        </div>
    </div>
</template>
<style>
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
    margin: 25px auto;
    border-radius: 8px;
    width: 595px;
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
        margin-bottom: 29px;
    }
    .close {
        cursor: pointer;
        font-weight: 600;
        font-size: 18px;
        color: #726c6c;
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
    margin-top: 26px;
  }
  .btn-cancel {
    background-color: #fff;
  }
  .btn-save {
    background-color:  #1A8FDD;
    color: #fff;
}
.btn {
    padding: 5px 30px;
    cursor: pointer;
    border-radius: 2px;
  }
  .column {
    display: flex;
    column-gap: 20px;
    margin-bottom: 10px;
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
  @media screen and (max-width: 520px) {
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
  }
  
</style>
