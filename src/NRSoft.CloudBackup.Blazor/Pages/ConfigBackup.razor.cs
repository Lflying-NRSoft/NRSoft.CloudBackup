using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using NRSoft.CloudBackup.ConfigBackups;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace NRSoft.CloudBackup.Blazor.Pages
{
    public partial class ConfigBackup
    {
        [Inject]
        private IConfigBackupAppService ConfigBackupAppService { get; set; }

        [NotNull]
        private List<ConfigBackupDto> Items { get; set; } = new List<ConfigBackupDto>();

        /// <summary>
        /// 分页下拉框
        /// </summary>
        private static IEnumerable<int> PageItemsSource => new int[] { 10, 20, 50, 100 };

        /// <summary>
        /// 页面初始化逻辑
        /// </summary>
        protected async override Task OnInitializedAsync()
        {
            Items = await ConfigBackupAppService.GetListAsync();
        }

        /// <summary>
        /// 新增时的默认对象
        /// </summary>
        /// <returns></returns>
        private Task<ConfigBackupDto> OnAddAsync()
        {
            var item = new ConfigBackupDto();
            return Task.FromResult(item);
        }

        /// <summary>
        /// 保持逻辑
        /// </summary>
        /// <param name="dto">对象</param>
        /// <returns></returns>
        private async Task<bool> OnSaveAsync(ConfigBackupDto dto)
        {
            // 增加数据演示代码
            if (dto.Id == Guid.Empty)
            {
                dto.Id = Guid.NewGuid();
                var result = await ConfigBackupAppService.CreateAsync(dto.Content);
                Items.Add(result);
            }
            else
            {
                var oldItem = Items.FirstOrDefault(i => i.Id == dto.Id);
                if (oldItem != null)
                {
                    Items.Remove(oldItem);
                    await ConfigBackupAppService.DeleteAsync(oldItem.Id);
                    var result = await ConfigBackupAppService.CreateAsync(dto.Content);
                }

            }
            return true;
        }

        /// <summary>
        /// 删除逻辑
        /// </summary>
        /// <param name="items">对象集合</param>
        /// <returns></returns>
        private async Task<bool> OnDeleteAsync(IEnumerable<ConfigBackupDto> items)
        {
            foreach (var item in items.ToList())
            {
                await ConfigBackupAppService.DeleteAsync(item.Id);
                Items.Remove(item);
            }
            return true;
        }

        /// <summary>
        /// 查询逻辑
        /// </summary>
        /// <param name="options">查询条件</param>
        /// <returns></returns>
        private async Task<QueryData<ConfigBackupDto>> OnQueryAsync(QueryPageOptions options)
        {
            Items = await ConfigBackupAppService.GetListAsync();
            IEnumerable<ConfigBackupDto> items = Items;

            // 过滤
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<ConfigBackupDto>());
                isFiltered = true;
            }

            // 排序
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                //var invoker = SortLambdaCache.GetOrAdd(typeof(Foo), key => LambdaExtensions.GetSortLambda<Foo>().Compile());
                //items = invoker(items, options.SortName, options.SortOrder);
                //isSorted = true;
            }

            // 设置记录总数
            var total = items.Count();

            // 内存分页
            items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList();

            return new QueryData<ConfigBackupDto>()
            {
                Items = items,
                TotalCount = total,
                IsSorted = isSorted,
                IsFiltered = isFiltered,
                IsSearch = true
            };
        }
    }
}
