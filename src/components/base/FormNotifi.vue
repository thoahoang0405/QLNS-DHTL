<template>
    <div class="notification-wrap">
            <div class="notification">
                <div class="warring">
                    <div>
                         <div class="icon-warning"></div>
                    </div>
                   
                    <div class="warrning-title">Thông tin bạn vừa nhập chưa được lưu. Bạn có muốn hủy thông tin?</div>
                </div>
                <div class="btn-wrap">
                    <div class="btnNotifi btn-secondary" @click="CancelNotifi">Hủy</div>
                    <div class="btnNotifi btn-primary" @click="noClick">Không</div>
                </div>
            </div>
    </div>
</template>

<script>
     export default {
        data(){
            return {
                // isShowNotifi: false
            }
        },
        components: {
        },

        methods: {
            noClick() {
                this.$emit('closeNotifi',false)
            },
            CancelNotifi() {
                this.$emit('cancelNotifi',false)
            }
        }
    }
</script>
<style>
.notification-wrap {
    background-color: rgba(0, 0, 0, 0.2);
    z-index: 3 !important;
    width: 100%;
    height: 100%;
    margin: auto;
    position: fixed;
    display: flex;
  
    }
    .notification{
        z-index: 5;
        position: absolute;
        left: 50%;
        top: 50%;
        transform: translate(-50%,-50%);
        background-color: #fff;
        width: 420px;
        height: 150px;
        padding: 20px;
        border-radius: 2px;
        box-shadow: rgba(50, 50, 93, 0.25) 0px 13px 27px -5px, rgba(0, 0, 0, 0.3) 0px 8px 16px -8px;
    }
    .warring{
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
    .warrning-title{
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
    .btnNotifi{   
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
        color: #fff;
    }
    .btn-secondary{
        border: 1px solid #1A8FDD;
        height: 25px;
    }
    .btn-primary:hover{
        color: #1A8FDD;
    }
    .btn-primary{
        margin-right: 40px;
        background-color: #1A8FDD;
        color: #fff;
        height: 25px;
    }
    @media screen and (max-width: 767.98px) {
        .notification{
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
    }</style>