import axios from 'axios';

declare module 'axios' {
    export interface AxiosResponse<data = any> extends Promise<data> { }
}
